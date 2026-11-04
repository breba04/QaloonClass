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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using UI.Users;
using UI.Circles;

namespace UI.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        enum enDashboardView
        {
            Circles,
            Users
        }
        enDashboardView DashboardView;
        private DataTable _dtUsers;
        private DataTable _dtCircles;
        private DataTable _allData;
        private byte _pageSize = 7;
        private byte _currentPage = 1;
        private int _totalPages = 1;
        private Button SelectedButton { get => btn_Users.BackColor == ColorTranslator.FromHtml(ColorNeutral) ? btn_Users : btn_Circles; }
        private readonly string ColorSuccess = "#002819";
        private readonly string ColorWarning = "#d35400";
        private readonly string ColorDanger = "#BA1A1A";
        private readonly string ColorNeutral = "#7F8C8D";

        [Description("Initializes the user control components, subscribes to events, and hooks up the disposal action.")]
        public UC_Dashboard()
        {
            InitializeComponent();
            DashboardView = enDashboardView.Circles;
            clsAppEvents.StudentAdded += AppEvents_StudentAdded;
            clsUsers.UserAddedOrUpdated += Event_UserAddedOrUpdated;
            clsCircles.OnCircleAddedOrUpdated += Event_CircleAddedOrUpdated;
            // UserControl إلغاء الاشتراك تلقائياً عند تدمير الـ 
            // لمنع تسريب الذاكرة

            this.Disposed += (sender, e) =>
            {
                clsAppEvents.StudentAdded -= AppEvents_StudentAdded;
                clsUsers.UserAddedOrUpdated -= Event_UserAddedOrUpdated;
                clsCircles.OnCircleAddedOrUpdated -= Event_CircleAddedOrUpdated;
            };
        }
        private void _HandelCirclesAndUsersButtonsColor(Button button)
        {
            btn_Users.BackColor = ColorTranslator.FromHtml(ColorSuccess);
            btn_Circles.BackColor = ColorTranslator.FromHtml(ColorSuccess);
            
            btn_Users.ForeColor = Color.White;
            btn_Circles.ForeColor = Color.White;

            button.BackColor = ColorTranslator.FromHtml(ColorNeutral);
            button.ForeColor = Color.Black;
        }
        private void _HandelCirclesAndUsersDashboardView(Button button)
        {
            DashboardView = button == btn_Circles ? enDashboardView.Circles : enDashboardView.Users;
            dgv_Listreports.ContextMenuStrip = DashboardView == enDashboardView.Circles ? cMinu_Circles : cMinu_Users;
        }
        private void _InitializeDashpord()
        {
            DashboardView = enDashboardView.Circles;
            _HandelCirclesAndUsersButtonsColor(btn_Circles);
            _HandelCirclesAndUsersDashboardView(btn_Circles);
            lbl_SubTitle.Text = $".مرحباً بك في لوحة تحكم {clsGlobal.CenterName}. إليك نظرة شاملة على تقدم الطلاب وحلقات الذكر لهذا اليوم المبارك";
        }
        private void _LoadsUserDataFromDB()
        {
            _dtUsers = clsUsers.SelectAllTeachers();
        }
        private void _LoadsCircleDataFromDB()
        {
            _dtCircles = clsCircles.SelectAllCircles();
        }
        private void _LoadDataFromDB()
        {
            _LoadsCircleDataFromDB();
            _LoadsUserDataFromDB();
        }

        [Description("Event handler triggered when a new student is added, forcing the dashboard to refresh.")]
        private void AppEvents_StudentAdded(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        [Description("Calculates the total number of students accurately from the complete dataset using LINQ.")]
        //private int _GetTotalNumberStudent()
        //{
        //    if (_dtCircles == null || _dtCircles.Rows.Count == 0) return 0;

        //    return _dtCircles.AsEnumerable()
        //                   .Where(row => row["CurrentStudentNumbers"] != DBNull.Value)
        //                   .Sum(row => Convert.ToInt32(row["CurrentStudentNumbers"]));
        //}
        private int _GetTotalNumberTeachers()
        {
            if (_dtUsers == null || _dtUsers.Rows.Count == 0) return 0;

            return _dtUsers.AsEnumerable().Count();
        }
        private int _GetTotalNumberSeats()
        {
            if (_dtCircles == null || _dtCircles.Rows.Count == 0) return 0;
            try
            {
                return _dtCircles.AsEnumerable().Where(row => row["MaxCapacity"] != null).Sum(row => Convert.ToInt32( row["MaxCapacity"]));
            }
            catch(Exception)
            {
                return 0;
            }
        }
        private int _GetAvailableNumberSeats()
        {
            if (_dtCircles == null || _dtCircles.Rows.Count == 0) return 0;
            try
            {
                int AvailableSeats = _GetTotalNumberSeats() - _dtCircles.AsEnumerable().
                    Where(row => row["CurrentStudentNumbers"] != null).Sum(row => Convert.ToInt32(row["CurrentStudentNumbers"]));
                return AvailableSeats;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        [Description("Loads main dashboard text elements, user welcome message, and general statistical counters.")]
        private void _LoadMainData()
        {
            lbl_Welcome.Text = $"السلام عليكم، يا شيخ {clsCurrentUser.CurrentUser.FirstName}";
            lbl_TotalCircles.Text = _allData?.Rows.Count.ToString() ?? "0";
            lbl_TotalTeachers.Text = _GetTotalNumberTeachers().ToString()?? "0";
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
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CircleID"], "معرف الحلقة", 70);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CircleName"], "اسم الحلقة", 100);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["Timeing"], "التوقيت", 100);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["TeacherName"], "المعلم", 100);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["CurrentStudentNumbers"], "عدد الطلبة الحاليين", 100);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["MaxCapacity"], "عدد المقاعد", 100);

                dgv_Listreports.Columns["TeacherID"].Visible = false;

            }
            else if (dgv_Listreports.Columns.Contains("UserID"))
            {
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["UserID"], "معرف المعلم", 70);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["UserName"], "اسم المستخدم", 100);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["TeacherName"], "الاسم الكامل", 200);
                clsUtil.ConfigureColumn(dgv_Listreports.Columns["UserRoleName"], "الوظيفة", 100);
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
            lbl_AvailableSeats.ForeColor = ColorTranslator.FromHtml(color);
            lb_Card4Title.ForeColor = ColorTranslator.FromHtml(color);
            lbl_TotalNumberOfSeats.ForeColor = ColorTranslator.FromHtml(color);
            lbl_TotalNumberOfSeats.Text = message;
            ptb_StatusIcon.Image = icon;
            pnl_AbsenceAlerts.BackColor = Color.FromArgb(50, ColorTranslator.FromHtml(color));
        }


        [Description("Updates the absence alert indicator box styles, colors, and warning messages based on total absence counts.")]
        private void _ApplyAbsenceStatusStyle(int absenceCount)
        {
            int safeAbsenceCount = Math.Max(0, absenceCount);
            lbl_AvailableSeats.Text = safeAbsenceCount.ToString();



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
        private void _ApplyAvailableSeatsStyle(int TotalSeatsCount,int AvailableSeatsCount)
        {
            if (TotalSeatsCount >= AvailableSeatsCount)
            {
                _UpdateAbsenceStatusUI("الوضع مستقر حالياً", ColorSuccess, Properties.Resources.ic_info);
            }
            else 
            {
                _UpdateAbsenceStatusUI("يتطلب تدخل المشرف فوراً", ColorDanger, Properties.Resources.ic_alert_urgent);
            }
        }

        [Description("Handles the user control load event to trigger the initial dashboard refresh.")]
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            _InitializeDashpord();
            _LoadDataFromDB();
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
            _allData = DashboardView == enDashboardView.Circles ? _dtCircles
                : _dtUsers;

            _ApplyStudentsStyle(clsStudents.GetNewStudentsStatusLastMonth());
            //_ApplyAbsenceStatusStyle(clsStudents.GetTotalStudentAbsentLastMonth());

            //lbl_TotalNumberOfSeats.Text = $"من :{_GetTotalNumberSeats()}";

            int AvailableSeatsCount = _GetAvailableNumberSeats();
            lbl_AvailableSeats.Text = AvailableSeatsCount.ToString();
            _ApplyAvailableSeatsStyle(_GetTotalNumberSeats(),AvailableSeatsCount);
            _ApplyCirclesStyle(clsCircles.GetNewCirclesStatsLastMonth());


            _LoadPage();
            _LoadMainData();

        }
        private void btn_Circles_Click(object sender, EventArgs e)
        {
            _HandelCirclesAndUsersButtonsColor(sender as Button);
            _HandelCirclesAndUsersDashboardView(sender as Button);
            RefreshDashboard();
        }
        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateUser frm = new frmAddAndUpdateUser();
            frm.ShowDialog();
            RefreshDashboard();
        }
        private void UpdateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgv_Listreports.CurrentRow.Cells["UserID"].Value.ToString(), out int selectedUserID))
            {
                frmAddAndUpdateUser frm = new frmAddAndUpdateUser(selectedUserID);
                frm.ShowDialog();
                RefreshDashboard();
            }
        }
        private void dgv_Listreports_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgv_Listreports.ClearSelection();
                dgv_Listreports.Rows[e.RowIndex].Selected = true;
                dgv_Listreports.CurrentCell = dgv_Listreports.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void Event_UserAddedOrUpdated()
        {
            _LoadsUserDataFromDB();
            RefreshDashboard();
        }
        private void Event_CircleAddedOrUpdated(int CircleID)
        {
            _LoadsCircleDataFromDB();
            RefreshDashboard();
        }
        private void AddCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCircle frm = new frmAddUpdateCircle();
            frm.ShowDialog();
        }

        private void UpdateCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgv_Listreports.CurrentRow.Cells["CircleID"].Value.ToString(), out int selectedCircleID))
            {
                frmAddUpdateCircle frm = new frmAddUpdateCircle(selectedCircleID);
                frm.ShowDialog();
            }
        }
    }
}