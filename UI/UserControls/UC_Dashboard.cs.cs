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
        void LoadMainData()
        {
            lbl_FirstName.Text = clsCurrentUser.CurrentUser.FirstName;
            lbl_TotalCircles.Text = dgv_Listreports.RowCount.ToString();
            lbl_TotalStudents.Text = _GetTotalNumberStudent().ToString();
        }
        private void LoadPage()
        {
            //if (_allData == null || _allData.Rows.Count == 0) return;

            //IEnumerable<DataRow> pagedData = _allData.AsEnumerable()
            //                       .Skip((_currentPage - 1) * _pageSize)
            //                       .Take(_pageSize);

            //if (pagedData.Any())
                //{
                //    dgv_Listreports.DataSource = pagedData.CopyToDataTable();
                //}
                //else
                //{
                //    dgv_Listreports.DataSource = null;
                //}

                //_totalPages = (int)Math.Ceiling((double)_allData.Rows.Count / _pageSize);
                //lbl_PageNumbering.Text = $"صفحة {_currentPage} من {_totalPages}";
                _allData = clsCircles.GetAllCircleView(_currentPage, _RecordsInPage);
            if (_allData == null || _allData.Rows.Count == 0) return;
            dgv_Listreports.DataSource = _allData;
            UpdatePaginationStatus();
        }
        private void UpdatePaginationStatus()
        {
            btn_Previous.Enabled = (_currentPage > 1);
            btn_Next.Enabled = (_currentPage < _totalPages);
        }
        public DataTable GetHalaqatDemoData()
        {
            DataTable dt = new DataTable("HalaqatData");

            dt.Columns.Add("اسم الحلقة", typeof(string));
            dt.Columns.Add("المشرف المسؤول", typeof(string));
            dt.Columns.Add("عدد الطلاب", typeof(int));
            dt.Columns.Add("معدل الحفظ", typeof(int));
            dt.Columns.Add("الحالة العامة", typeof(string));

            dt.Rows.Add("حلقة الأبرار", "محمد عليان", 22, 14, "تطور ممتاز");
            dt.Rows.Add("حلقة التبيان", "سليمان الرشيد", 15, -4, "تراجع ملحوظ");
            dt.Rows.Add("حلقة البينة", "سعد المالكي", 19, 0, "مستقر");
            dt.Rows.Add("حلقة القلم", "إبراهيم خليل", 27, 9, "جيد جداً");
            dt.Rows.Add("حلقة المرتضى", "ياسر الشهري", 12, 25, "نمو استثنائي");
            dt.Rows.Add("حلقة الفرقان", "بدر العتيبي", 31, -8, "ضعيف جداً");
            dt.Rows.Add("حلقة المجتبى", "أسامة العبد", 20, 6, "جيد");
            dt.Rows.Add("حلقة النبأ", "حمزة يوسف", 17, 3, "تحسن طفيف");
            dt.Rows.Add("حلقة السراج", "فيصل الحربي", 24, 0, "مستقر");
            dt.Rows.Add("حلقة الضياء", "عادل القحطاني", 29, 18, "أداء متميز");
            dt.Rows.Add("حلقة المصباح", "تركي الشمري", 14, -2, "يحتاج متابعة");
            dt.Rows.Add("حلقة تبارك", "سلطان العنزي", 26, 11, "تطور جيد");
            dt.Rows.Add("حلقة الرحمن", "فهد الدوسري", 21, 5, "جيد");
            dt.Rows.Add("حلقة يس", "راشد المري", 18, -12, "تنبيه غياب");
            dt.Rows.Add("حلقة طه", "علي الزهراني", 23, 7, "جيد جداً");
            dt.Rows.Add("حلقة الفتح", "نواف المطيري", 16, 22, "تطور سريع");
            dt.Rows.Add("حلقة النصر", "مشاري البقمي", 30, 0, "ثبات في الأداء");
            dt.Rows.Add("حلقة الكهف", "باسم الغامدي", 13, -5, "يحتاج تشجيع");
            dt.Rows.Add("حلقة الملك", "هاشم الشريف", 28, 13, "مستوى متقدم");
            dt.Rows.Add("حلقة الإحسان", "خالد الرويلي", 25, 4, "تحسن مستمر");
            dt.Rows.Add("حلقة الأبرار", "محمد عليان", 22, 14, "تطور ممتاز");
            dt.Rows.Add("حلقة التبيان", "سليمان الرشيد", 15, -4, "تراجع ملحوظ");
            dt.Rows.Add("حلقة البينة", "سعد المالكي", 19, 0, "مستقر");
            dt.Rows.Add("حلقة القلم", "إبراهيم خليل", 27, 9, "جيد جداً");
            dt.Rows.Add("حلقة المرتضى", "ياسر الشهري", 12, 25, "نمو استثنائي");
            dt.Rows.Add("حلقة الفرقان", "بدر العتيبي", 31, -8, "ضعيف جداً");
            dt.Rows.Add("حلقة المجتبى", "أسامة العبد", 20, 6, "جيد");
            dt.Rows.Add("حلقة النبأ", "حمزة يوسف", 17, 3, "تحسن طفيف");
            dt.Rows.Add("حلقة السراج", "فيصل الحربي", 24, 0, "مستقر");
            dt.Rows.Add("حلقة الضياء", "عادل القحطاني", 29, 18, "أداء متميز");
            dt.Rows.Add("حلقة المصباح", "تركي الشمري", 14, -2, "يحتاج متابعة");
            dt.Rows.Add("حلقة تبارك", "سلطان العنزي", 26, 11, "تطور جيد");
            dt.Rows.Add("حلقة الرحمن", "فهد الدوسري", 21, 5, "جيد");
            dt.Rows.Add("حلقة يس", "راشد المري", 18, -12, "تنبيه غياب");
            dt.Rows.Add("حلقة طه", "علي الزهراني", 23, 7, "جيد جداً");
            dt.Rows.Add("حلقة الفتح", "نواف المطيري", 16, 22, "تطور سريع");
            dt.Rows.Add("حلقة النصر", "مشاري البقمي", 30, 0, "ثبات في الأداء");
            dt.Rows.Add("حلقة الكهف", "باسم الغامدي", 13, -5, "يحتاج تشجيع");
            dt.Rows.Add("حلقة الملك", "هاشم الشريف", 28, 13, "مستوى متقدم");
            dt.Rows.Add("حلقة الإحسان", "خالد الرويلي", 25, 4, "تحسن مستمر");


            return dt;
        }   
        private void _FormatDataGridView()
        {
            dgv_Listreports.EnableHeadersVisualStyles = false;

            Font headerFont = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv_Listreports.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgv_Listreports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_Listreports.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#002819");
            dgv_Listreports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_Listreports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Listreports.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Listreports.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2E4F3F");
            dgv_Listreports.RowTemplate.Height = 35;

            dgv_Listreports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Listreports.ColumnHeadersHeight = 50;

            dgv_Listreports.GridColor = Color.LightGray;

            //dgv_Listreports.Columns["معدل الحفظ"].DefaultCellStyle.Format = "0'%'";
        }
        private void UpdateStudentsStyle(int NumberOfStudentLastMonth ,string ForeColor,Bitmap ResourcesImage,string prefix = "")
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
        private void ApplyStudentsStyle(int rate)
        {
            if(rate > 0)
            {
                UpdateStudentsStyle(rate,"#002819", Properties.Resources.trending_up,"+");
            }
            else if(rate < 0)  
            {
                UpdateStudentsStyle(rate, "#BA1A1A", Properties.Resources.trending_down);
            }
            else
            {
                UpdateStudentsStyle(rate, "#7F8C8D", Properties.Resources.trending_Flat,"+");
            }
        }
        private void UpdateCirclesStyle(int NumberOfCirclesLastMonth, string ForeColor,Bitmap ResourcesImage,string prefix = "")
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
        private void ApplyCirclesStyle(int NumberOfCirclesLastMonth)
        {
            if(NumberOfCirclesLastMonth > 0)
            {
                UpdateCirclesStyle(NumberOfCirclesLastMonth, "#002819", Properties.Resources.trending_up,"+");
            }
            else if(NumberOfCirclesLastMonth < 0)  
            {
                UpdateCirclesStyle(NumberOfCirclesLastMonth, "#BA1A1A", Properties.Resources.trending_down);
            }
            else
            {
                UpdateCirclesStyle(NumberOfCirclesLastMonth, "#7F8C8D", Properties.Resources.trending_Flat,"+");
            }
        }
        private void UpdateAbsenceStatusStyle(string Message, string ForeColor , Bitmap ResourcesImage)
        {
            lbl_TotalAbsence.ForeColor = ColorTranslator.FromHtml(ForeColor);
            lbl_AbsenceAlerts.ForeColor = ColorTranslator.FromHtml(ForeColor);
            lbl_Status.ForeColor = ColorTranslator.FromHtml(ForeColor);
            lbl_Status.Text = Message;
            ptb_StatusIcon.Image = ResourcesImage;
            pnl_AbsenceAlerts.BackColor = Color.FromArgb(50, ColorTranslator.FromHtml(ForeColor));
        }
        private void ApplyAbsenceStatusStyle(int absenceCount)
        {
            lbl_TotalAbsence.Text = (absenceCount < 0 ) ? "0" : absenceCount.ToString();

            if (absenceCount <= 5)
            {
                UpdateAbsenceStatusStyle("الوضع مستقر حالياً", "#002819", Properties.Resources.ic_info);
            }
            else if (absenceCount > 5 && absenceCount <= 10)
            {
                UpdateAbsenceStatusStyle("يتطلب متابعة من المشرف", "#d35400", Properties.Resources.ic_warning);
            }
            else 
            {
                UpdateAbsenceStatusStyle("يتطلب تدخل المشرف فوراً", "#BA1A1A", Properties.Resources.ic_alert_urgent);             
            }
        }
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            _totalPages = clsCircles.GetTotalPagesRecordsInCircleView(_RecordsInPage);
            ApplyStudentsStyle(clsStudents.GetNewStudentsStatusLastMonth());
            ApplyAbsenceStatusStyle(clsStudents.GetTotalStudentAbsentLastMonth());
            ApplyCirclesStyle(clsCircles.GetNewCirclesStatsLastMonth());
            InitializeDashboard();
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadPage();

            }

        }
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadPage();
            }
        }
        private void InitializeDashboard()
        {
            //_allData = GetHalaqatDemoData();
            _currentPage = 1;
            LoadPage(); 
            _FormatDataGridView();
            LoadMainData();
            lbl_SubTitle.Text = $".مرحباً بك في لوحة تحكم {clsGlobal.CenterName}. إليك نظرة شاملة على تقدم الطلاب وحلقات الذكر لهذا اليوم المبارك";
        }
    }
    }
