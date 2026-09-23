using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel; // Required for Description attribute
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
        private byte _pageSize = 8;
        private byte _currentPage = 1;
        private int _totalPages = 1;

        private readonly string ColorSuccess = "#002819";
        private readonly string ColorWarning = "#d35400";
        private readonly string ColorDanger = "#BA1A1A";
        private readonly string ColorNeutral = "#7F8C8D";

        [Description("Initializes the user control components, subscribes to events, and hooks up the disposal action.")]
        public UC_Dashboard()
        {
            InitializeComponent();
            clsAppEvents.StudentAdded += AppEvents_StudentAdded;

            // UserControl إلغاء الاشتراك تلقائياً عند تدمير الـ 
            // لمنع تسريب الذاكرة

            this.Disposed += (sender, e) =>
            {
                clsAppEvents.StudentAdded -= AppEvents_StudentAdded;
            };
        }

        [Description("Event handler triggered when a new student is added, forcing the dashboard to refresh.")]
        private void AppEvents_StudentAdded(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        [Description("Calculates the total number of students accurately from the complete dataset using LINQ.")]
        private int _GetTotalNumberStudent()
        {
            if (_allData == null || _allData.Rows.Count == 0) return 0;

            return _allData.AsEnumerable()
                           .Where(row => row["Total Students"] != DBNull.Value)
                           .Sum(row => Convert.ToInt32(row["Total Students"]));
        }

        [Description("Loads main dashboard text elements, user welcome message, and general statistical counters.")]
        private void _LoadMainData()
        {
            lbl_Welcome.Text = $"السلام عليكم، يا شيخ {clsCurrentUser.CurrentUser.FirstName}";
            lbl_TotalCircles.Text = _allData?.Rows.Count.ToString() ?? "0";
            lbl_TotalStudents.Text = _GetTotalNumberStudent().ToString();
        }

        [Description("Calculates total pages based on record count and updates the pagination numbering label.")]
        private void _UpdatePageNumbering()
        {
            if (_allData == null || _allData.Rows.Count == 0)
            {
                _totalPages = 1;
                lbl_PageNumbering.Text = $"صفحة 1 من 1";
                return;
            }

            _totalPages = (int)(Math.Ceiling((double)_allData.Rows.Count / _pageSize));
            lbl_PageNumbering.Text = $"صفحة {_currentPage} من {_totalPages}";
        }

        [Description("Slices the dataset using LINQ Skip and Take methods to display the current page records in the grid.")]
        private void _LoadPage()
        {
            if (_allData == null || _allData.Rows.Count == 0)
            {
                dgv_Listreports.DataSource = null;
                return;
            }

            var pagedData = _allData.AsEnumerable()
                                    .Skip((_currentPage - 1) * _pageSize)
                                    .Take(_pageSize);

            if (pagedData.Any())
            {
                dgv_Listreports.DataSource = pagedData.CopyToDataTable();
                _FormatDataGridView();
            }
            else
                dgv_Listreports.DataSource = null;

            _UpdatePageNumbering();
            _UpdatePaginationStatus();
        }

        [Description("Enables or disables pagination navigation buttons (Next/Previous) depending on the active page.")]
        private void _UpdatePaginationStatus()
        {
            btn_Previous.Enabled = (_currentPage > 1);
            btn_Next.Enabled = (_currentPage < _totalPages);
        }

        [Description("Applies custom design styles and column configurations to the main DataGridView.")]
        private void _FormatDataGridView()
        {
            clsUtil.InitializeGridViewStyle(dgv_Listreports);

            if (dgv_Listreports.Columns.Contains("CircleID"))
            {
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CircleID"], "معرف الحلقة", 200);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CircleName"], "اسم الحلقة", 500);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["Total Students"], "إجمالي الطلاب", 200);
            }
        }

        [Description("Updates the UI style, color, and trending icon for student statistics compared to last month.")]
        private void _ApplyStudentsStyle(int rate)
        {
            string prefix = rate >= 0 ? "+" : "";
            string color = rate > 0 ? ColorSuccess : (rate < 0 ? ColorDanger : ColorNeutral);
            Bitmap icon = rate > 0 ? Properties.Resources.trending_up : (rate < 0 ? Properties.Resources.trending_down : Properties.Resources.trending_Flat);

            lbl_NumberOfStudentLastMonth.Text = $"{prefix}{rate} عن الشهر الماضي";
            lbl_NumberOfStudentLastMonth.ForeColor = ColorTranslator.FromHtml(color);
            ptb_TotalStudents_TrendingIcon.Image = icon;
        }

        [Description("Updates the UI style, color, and trending icon for circles statistics compared to last month.")]
        private void _ApplyCirclesStyle(int rate)
        {
            string prefix = rate >= 0 ? "+" : "";
            string color = rate > 0 ? ColorSuccess : (rate < 0 ? ColorDanger : ColorNeutral);
            Bitmap icon = rate > 0 ? Properties.Resources.trending_up : (rate < 0 ? Properties.Resources.trending_down : Properties.Resources.trending_Flat);

            lbl_NumberOfCirclesLastMonth.Text = $"{prefix}{rate} عن الشهر الماضي";
            lbl_NumberOfCirclesLastMonth.ForeColor = ColorTranslator.FromHtml(color);
            ptb_TotalCircles_TrendingIcon.Image = icon;
        }



        [Description("Applies the visual style, colors, messages, and icons directly to the absence alert UI elements.")]
        private void _UpdateAbsenceStatusUI(string message, string color, Bitmap icon)
        {
            lbl_TotalAbsence.ForeColor = ColorTranslator.FromHtml(color);
            lbl_AbsenceAlerts.ForeColor = ColorTranslator.FromHtml(color);
            lbl_Status.ForeColor = ColorTranslator.FromHtml(color);
            lbl_Status.Text = message;
            ptb_StatusIcon.Image = icon;
            pnl_AbsenceAlerts.BackColor = Color.FromArgb(50, ColorTranslator.FromHtml(color));
        }


        [Description("Updates the absence alert indicator box styles, colors, and warning messages based on total absence counts.")]
        private void _ApplyAbsenceStatusStyle(int absenceCount)
        {
            int safeAbsenceCount = Math.Max(0, absenceCount);
            lbl_TotalAbsence.Text = safeAbsenceCount.ToString();



            if (safeAbsenceCount <= 5)
            {
                _UpdateAbsenceStatusUI("الوضع مستقر حالياً", ColorSuccess, Properties.Resources.ic_info);
            }
            else if (safeAbsenceCount <= 10)
            {
                _UpdateAbsenceStatusUI("يتطلب متابعة من المشرف", ColorWarning, Properties.Resources.ic_warning);
            }
            else
            {
                _UpdateAbsenceStatusUI("يتطلب تدخل المشرف فوراً", ColorDanger, Properties.Resources.ic_alert_urgent);
            }
        }

        [Description("Handles the user control load event to trigger the initial dashboard refresh.")]
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            lbl_SubTitle.Text = $".مرحباً بك في لوحة تحكم {clsGlobal.CenterName}. إليك نظرة شاملة على تقدم الطلاب وحلقات الذكر لهذا اليوم المبارك";
            RefreshDashboard();
        }

        [Description("Handles the next page button click event to navigate forward through paginated data.")]
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                _LoadPage();
            }
        }

        [Description("Handles the previous page button click event to navigate backward through paginated data.")]
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                _LoadPage();
            }
        }

        [Description("The main core method responsible for fetching data, updating statistics, and refreshing the entire dashboard UI.")]
        public void RefreshDashboard()
        {
            _allData = clsCircles.GetAllCircleView(_currentPage, _pageSize);

            _ApplyStudentsStyle(clsStudents.GetNewStudentsStatusLastMonth());
            _ApplyAbsenceStatusStyle(clsStudents.GetTotalStudentAbsentLastMonth());
            _ApplyCirclesStyle(clsCircles.GetNewCirclesStatsLastMonth());
            _LoadPage();
            _LoadMainData();
        }
    }
}