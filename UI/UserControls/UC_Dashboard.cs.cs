using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.GlobalClasses;
using EntityLayer;

namespace UI.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        private DataTable _allData;
        private int _pageSize = 10; 
        private byte _currentPage = 1; 
        private int _totalPages = 1; 
        private byte _RecordsInPage = 8; 
        public UC_Dashboard()
        {
            InitializeComponent();
        }
        int _GetTotalNumberStudent()
        {
            int TotalStudents = 0;
            foreach (DataGridViewRow item in dgv_Listreports.Rows)
            {
                if (item.Cells[2].Value != null)
                    if(int.TryParse(item.Cells[2].Value.ToString(),out int result))
                    {
                        TotalStudents += result;
                    }
            }
            return TotalStudents;
        }
        private void _LoadMainData()
        {
            lbl_FirstName.Text = clsCurrentUser.CurrentUser.FirstName;
            lbl_TotalCircles.Text = dgv_Listreports.RowCount.ToString();
            lbl_TotalStudents.Text = _GetTotalNumberStudent().ToString();
        }
        private void _UpdatePageNumbering()
        {
            _totalPages = (int)Math.Ceiling((double)_allData.Rows.Count / _pageSize);
            lbl_PageNumbering.Text = $"صفحة {_currentPage} من {_totalPages}";
        }
        private void _LoadPage()
        {
            if (_allData == null || _allData.Rows.Count == 0) return;

            IEnumerable<DataRow> pagedData = _allData.AsEnumerable()
                                   .Skip((_currentPage - 1) * _pageSize)
                                   .Take(_pageSize);

            if (pagedData.Any())
            {
                dgv_Listreports.DataSource = pagedData.CopyToDataTable();
            }
            else
            {
                dgv_Listreports.DataSource = null;
            }

            _UpdatePageNumbering();

            _UpdatePaginationStatus();
        }
        private void _UpdatePaginationStatus()
        {
            btn_Previous.Enabled = (_currentPage > 1);
            btn_Next.Enabled = (_currentPage < _totalPages);
        }
        private void _FormatDataGridViewColumn()
        {
            if (dgv_Listreports.Rows.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CircleID"], "معرف الحلقة", 200);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CircleName"], "اسم الحلقة", 500);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["Total Students"], "إجمالي الطلاب", 200);
               
            }
        }
        private void _FormatDataGridView()
        {
            clsUtil.InitializeGridViewStyle(dgv_Listreports);
           _FormatDataGridViewColumn();
        }
        private void _UpdateStudentsStyle(int NumberOfStudentLastMonth ,string ForeColor,Bitmap ResourcesImage,string prefix = "")
        {
            if (string.IsNullOrEmpty(prefix))
            {
                lbl_NumberOfStudentLastMonth.Text = NumberOfStudentLastMonth  + " عن الشهر الماضي";
            }
            else
                lbl_NumberOfStudentLastMonth.Text = prefix + NumberOfStudentLastMonth  + " عن الشهر الماضي";

            lbl_NumberOfStudentLastMonth.ForeColor = ColorTranslator.FromHtml(ForeColor);
            ptb_TotalStudents_TrendingIcon.Image = ResourcesImage;
        }
        private void _ApplyStudentsStyle(int rate)
        {
            if(rate > 0)
            {
                _UpdateStudentsStyle(rate,"#002819", Properties.Resources.trending_up,"+");
            }
            else if(rate < 0)  
            {
                _UpdateStudentsStyle(rate, "#BA1A1A", Properties.Resources.trending_down);
            }
            else
            {
                _UpdateStudentsStyle(rate, "#7F8C8D", Properties.Resources.trending_Flat,"+");
            }
        }
        private void _UpdateCirclesStyle(int NumberOfCirclesLastMonth, string ForeColor,Bitmap ResourcesImage,string prefix = "")
        {
            if (string.IsNullOrEmpty(prefix))
            {
                lbl_NumberOfCirclesLastMonth.Text = NumberOfCirclesLastMonth  + " عن الشهر الماضي";
            }
            else
                lbl_NumberOfCirclesLastMonth.Text = prefix + NumberOfCirclesLastMonth + " عن الشهر الماضي";

            lbl_NumberOfCirclesLastMonth.ForeColor = ColorTranslator.FromHtml(ForeColor);
            ptb_TotalCircles_TrendingIcon.Image = ResourcesImage;
        }
        private void _ApplyCirclesStyle(int NumberOfCirclesLastMonth)
        {
            if(NumberOfCirclesLastMonth > 0)
            {
                _UpdateCirclesStyle(NumberOfCirclesLastMonth, "#002819", Properties.Resources.trending_up,"+");
            }
            else if(NumberOfCirclesLastMonth < 0)  
            {
                _UpdateCirclesStyle(NumberOfCirclesLastMonth, "#BA1A1A", Properties.Resources.trending_down);
            }
            else
            {
                _UpdateCirclesStyle(NumberOfCirclesLastMonth, "#7F8C8D", Properties.Resources.trending_Flat,"+");
            }
        }
        private void _UpdateAbsenceStatusStyle(string Message, string ForeColor , Bitmap ResourcesImage)
        {
            lbl_TotalAbsence.ForeColor = ColorTranslator.FromHtml(ForeColor);
            lbl_AbsenceAlerts.ForeColor = ColorTranslator.FromHtml(ForeColor);
            lbl_Status.ForeColor = ColorTranslator.FromHtml(ForeColor);
            lbl_Status.Text = Message;
            ptb_StatusIcon.Image = ResourcesImage;
            pnl_AbsenceAlerts.BackColor = Color.FromArgb(50, ColorTranslator.FromHtml(ForeColor));
        }
        private void _ApplyAbsenceStatusStyle(int absenceCount)
        {
            lbl_TotalAbsence.Text = (absenceCount < 0 ) ? "0" : absenceCount.ToString();

            if (absenceCount <= 5)
            {
                _UpdateAbsenceStatusStyle("الوضع مستقر حالياً", "#002819", Properties.Resources.ic_info);
            }
            else if (absenceCount > 5 && absenceCount <= 10)
            {
                _UpdateAbsenceStatusStyle("يتطلب متابعة من المشرف", "#d35400", Properties.Resources.ic_warning);
            }
            else 
            {
                _UpdateAbsenceStatusStyle("يتطلب تدخل المشرف فوراً", "#BA1A1A", Properties.Resources.ic_alert_urgent);             
            }
        }
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            _ApplyStudentsStyle(clsStudents.GetNewStudentsStatusLastMonth());
            _ApplyAbsenceStatusStyle(clsStudents.GetTotalStudentAbsentLastMonth());
            _ApplyCirclesStyle(clsCircles.GetNewCirclesStatsLastMonth());
            _InitializeDashboard();
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                _LoadPage();

            }

        }
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                _LoadPage();
            }
        }
        private void _InitializeDashboard()
        {
            _allData = clsCircles.GetAllCircleView(_currentPage, _RecordsInPage);
            _currentPage = 1;
            _LoadPage(); 
            _FormatDataGridView();
            _LoadMainData();
            lbl_SubTitle.Text = $".مرحباً بك في لوحة تحكم {clsGlobal.CenterName}. إليك نظرة شاملة على تقدم الطلاب وحلقات الذكر لهذا اليوم المبارك";
        }
    }
    }
