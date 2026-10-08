using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GlobalClasses;

namespace UI.Reports.UserControl
{
    public partial class UC_Reports : System.Windows.Forms.UserControl
    {
        private readonly Color _ClickedBackColor;
        private readonly Color _NotClickedBackColor;
        private readonly Color _ClickedForeColor;
        private readonly Color _NotClickedForeColor;
        private short _CurrentPage;
        private short _TotalPages;
        private DataTable _dtCircles; 
        private DataTable _dtStudents;
        bool _IsLodding;
        private Button _CurrentReportBtn => btn_AttendanceReports.BackColor == _ClickedBackColor? btn_AttendanceReports 
            : btn_GlobelReports.BackColor == _ClickedBackColor? btn_GlobelReports 
            : btn_StudentsReports;
        private clsReports.enReportType _CurrentReportType => (clsReports.enReportType)(cmb_ReportType.SelectedValue ?? clsReports.enReportType.AllStudent);
        clsReports _AttendanceReports;
        List<clsEntityAttandanceReports.clsCircleAttendanceDetail> _ListCircleAttendanceDetail => _AttendanceReports.CircleAttendanceDetail;
        List<clsEntityAttandanceReports.clsStudentAttendanceDetail> _ListStudentAttendanceDetail => _AttendanceReports.StudentAttendanceDetail;
        public UC_Reports()
        {
            InitializeComponent();
            _ClickedBackColor = btn_GlobelReports.BackColor;
            _ClickedForeColor = btn_GlobelReports.ForeColor;
            _NotClickedBackColor = btn_AttendanceReports.BackColor;
            _NotClickedForeColor = btn_AttendanceReports.ForeColor;
            _AttendanceReports = new clsReports();
            _CurrentPage = 1;
            _TotalPages = 0;
            _IsLodding = false;
        }
        private void _LoadReportTypeData()
        {
            var reportTypes = new[]
            {
                new { Text = "تقرير شامل الطلاب", Value = clsReports.enReportType.AllStudent },
                new { Text = "تقرير طالب", Value = clsReports.enReportType.OneStudent }
            };

            cmb_ReportType.DataSource = reportTypes;
            cmb_ReportType.DisplayMember = "Text";
            cmb_ReportType.ValueMember = "Value";
        }
        private void _HandelItemAllCirclesInComboBox(clsReports.enReportType type)
        {
            if (type == clsReports.enReportType.AllStudent)
            {
                DataRow row = _dtCircles.NewRow();
                row["CircleID"] = -1;
                row["CircleName"] = "كل الحلقات";
                _dtCircles.Rows.InsertAt(row, 0);
            }
            else
            {
                var existingRow = _dtCircles.Select("CircleID = -1").FirstOrDefault();
                if(existingRow != null)
                    _dtCircles.Rows.Remove(existingRow);
            }
        }
        private void _LoadCirclesData()
        {
            _dtCircles = clsCircles.SelectAllCirclesMiniData();
            _HandelItemAllCirclesInComboBox(clsReports.enReportType.AllStudent);
        }
        private void _LoadStudentData()
        {
            byte selectedID = Convert.ToByte(cmb_Circles.SelectedValue);
            _dtStudents = clsStudents.SelectAllStudentsMiniData(selectedID);
        }
        private void _FillCirclesInComoboBox()
        {
            if (_dtCircles != null && _dtCircles.Rows.Count > 0)
            {
                cmb_Circles.DataSource = _dtCircles;
                cmb_Circles.DisplayMember = "CircleName";
                cmb_Circles.ValueMember = "CircleID";
            }
        }
        private void _FillStudentsInComoboBox()
        {
            if (_dtStudents != null && _dtStudents.Rows.Count > 0)
            {
                cmb_Students.DataSource = _dtStudents;
                cmb_Students.DisplayMember = "FullName";
                cmb_Students.ValueMember = "StudentID";
            }
        }
        private void _HandleReportCard1TextInAttendanceReports()
        {
            lb_TopTitleCard1.Text =
                        _CurrentReportType == clsReports.enReportType.AllStudent
                            ? "إجمالي الطلاب"
                            : "عدد أيام التسجيل";

            lb_BottomTitleCard1.Text =
                _CurrentReportType == clsReports.enReportType.AllStudent
                    ? "طالبًا مسجلًا"
                    : "للطالب المحدد";

        }
        private void _HandleReportCardsText(string btnName)
        {
            switch (btnName)
            {
                // تقرير الحضور والغياب
                case nameof(btn_AttendanceReports):


                    _HandleReportCard1TextInAttendanceReports();
                    lb_TopTitleCard2.Text = "أيام الحضور";
                    lb_BottomTitleCard2.Text = "إجمالي حالات الحضور";


                    lb_TopTitleCard3.Text = "أيام الغياب";
                    lb_BottomTitleCard3.Text = "خلال الفترة المحددة";


                    lb_TopTitleCard4.Text = "نسبة الحضور";
                    lb_BottomTitleCard4.Text = "من إجمالي سجلات الحضور";

                    break;


                // التقرير الشامل للطلاب
                case nameof(btn_GlobelReports):

                    lb_TopTitleCard1.Text = "إجمالي الطلاب";
                    lb_BottomTitleCard1.Text = "الطلاب المسجلون";


                    lb_TopTitleCard2.Text = "الطلاب النشطون";
                    lb_BottomTitleCard2.Text = "من إجمالي الطلاب";


                    lb_TopTitleCard3.Text = "الطلاب المتوقفون";
                    lb_BottomTitleCard3.Text = "من إجمالي الطلاب";


                    lb_TopTitleCard4.Text = "نسبة النشاط";
                    lb_BottomTitleCard4.Text = "من إجمالي الطلاب";

                    break;


                // تقرير الاختبارات الدورية
                case nameof(btn_StudentsReports):

                    lb_TopTitleCard1.Text = "إجمالي الطلاب";
                    lb_BottomTitleCard1.Text = "الطلاب المشاركون";


                    lb_TopTitleCard2.Text = "ناجحون";
                    lb_BottomTitleCard2.Text = "في الاختبار";


                    lb_TopTitleCard3.Text = "لم يجتازوا";
                    lb_BottomTitleCard3.Text = "في الاختبار";


                    lb_TopTitleCard4.Text = "نسبة النجاح";
                    lb_BottomTitleCard4.Text = "من إجمالي المشاركين";

                    break;
            }
        }
        private void _FillAttendanceReportCards()
        {
            if(_AttendanceReports != null)
            {

                lb_CenterTitleCard1.Text = _CurrentReportType == clsReports.enReportType.AllStudent
                    ? $"{_AttendanceReports.TotalStudentNumbers}"
                    : _AttendanceReports.TotalRegistrationDays.ToString();

                lb_CenterTitleCard2.Text = _AttendanceReports.TotalPresentDays.ToString();
                lb_CenterTitleCard3.Text = _AttendanceReports.TotalAbsentDays.ToString();
                lb_CenterTitleCard4.Text = $"{_AttendanceReports.AttendancePercentage:F2}%";
            }
        }
        private void _FormatDataGridViewColumnAttendanceReport()
        {
            if (dgv_ReportData.Columns.Count > 0)
            {
                if (_CurrentReportType == clsReports.enReportType.AllStudent)
                {

                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["FullName"], "اسم الطالب", 220);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["CircleName"], "الحلقة", 150);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["TeacherName"], "المعلم", 150);

                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["TotalPresent"], "حضور", 90);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["TotalAbsent"], "غياب", 90);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["TotalExcusedAbsent"], "غياب بإذن", 110);

                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["AttendancePercentage"], "نسبة الحضور", 110);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["Status"], "الحالة", 120);
                }
                else
                {
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["StatusName"], "الحالة", 220);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["AttendanceDate"], "تاريخ التسجيل", 220);
                    clsUtil.ConfigureColumn(dgv_ReportData.Columns["Notes"], "ملاحظات", 220);
                }
            }
        }
        private void _FormatDataGridViewColumnComprehensiveReport()
        {
            if (dgv_ReportData.Columns.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["FullName"], "اسم الطالب", 220);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["CircleName"], "الحلقة", 150);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["TeacherName"], "المعلم", 150);

                clsUtil.ConfigureColumn(dgv_ReportData.Columns["CurrentProgress"], "المحفوظ الحالي", 150);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["AttendancePercentage"], "نسبة الحضور", 110);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["LastEvaluation"], "آخر تقييم", 120);

                clsUtil.ConfigureColumn(dgv_ReportData.Columns["StudentStatus"], "الحالة", 120);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["Notes"], "الملاحظات", 220);
            }
        }
        private void _FormatDataGridViewColumnExamsReport()
        {
            if (dgv_ReportData.Columns.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["FullName"], "اسم الطالب", 220);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["CircleName"], "الحلقة", 150);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["TeacherName"], "المعلم", 150);

                clsUtil.ConfigureColumn(dgv_ReportData.Columns["EvaluationName"], "الاختبار", 180);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["EvaluationDate"], "تاريخ الاختبار", 110);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["EvaluationRate"], "الدرجة", 90);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["EvaluationFromAya"], "المحفوظ المختبر", 180);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["EvaluationToAya"], "المحفوظ المختبر", 180);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["Notes"], "الملاحظات", 220);
            }
        }
        private void _FormatDataGridViewColumn()
        {
            switch(_CurrentReportBtn.Name)
            {
                case nameof(btn_AttendanceReports):
                    _FormatDataGridViewColumnAttendanceReport();
                    break;
                case nameof(btn_GlobelReports):
                    _FormatDataGridViewColumnComprehensiveReport();
                    break;
                case nameof(btn_StudentsReports):
                    _FormatDataGridViewColumnExamsReport();
                    break;
            }

        }
        private void _FormatDataGridView()
        {
            clsUtil.InitializeGridViewStyle(dgv_ReportData);
            _FormatDataGridViewColumn();
        }
        private void InitializeGridView()
        {
            var Today = DateTime.Today;
            dtp_DateFrom.MaxDate = Today;
            dtp_DateTo.MaxDate = Today;
            dtp_DateTo.MinDate = dtp_DateFrom.Value;
            dtp_DateFrom.Value = DateTime.Now.Date.Day == 1 ? Today.AddMonths(-1) : new DateTime(Today.Year,Today.Month,1);
            _IsLodding = true;
            _LoadCirclesData();
            _LoadReportTypeData();

            _FillCirclesInComoboBox();
            cmb_ReportType.SelectedIndex = 0;
            _IsLodding = false;
        }
        void _ChangeBtnsColor(Button btn)
        {
            btn_AttendanceReports.BackColor = _NotClickedBackColor;
            btn_AttendanceReports.ForeColor = _NotClickedForeColor;
            btn_AttendanceReports.FlatStyle = FlatStyle.Standard;

            btn_GlobelReports.BackColor = _NotClickedBackColor;
            btn_GlobelReports.ForeColor = _NotClickedForeColor;
            btn_GlobelReports.FlatStyle = FlatStyle.Standard;

            btn_StudentsReports.BackColor = _NotClickedBackColor;
            btn_StudentsReports.ForeColor = _NotClickedForeColor;
            btn_StudentsReports.FlatStyle = FlatStyle.Standard;

            btn.BackColor = _ClickedBackColor;
            btn.ForeColor = _ClickedForeColor;
            btn.FlatStyle = FlatStyle.Flat;
        }
        void _LoadAttendanceReport()
        {
            int ID = _CurrentReportType == clsReports.enReportType.AllStudent ? Convert.ToInt32(cmb_Circles.SelectedValue ?? -1) 
                : Convert.ToInt32(cmb_Students.SelectedValue ?? -1);

            _TotalPages = _AttendanceReports.GenarateAttandanceReport(ID, dtp_DateFrom.Value, dtp_DateTo.Value, _CurrentPage, 10, _CurrentReportType);
            if(_CurrentReportType == clsReports.enReportType.AllStudent)
            {
                dgv_ReportData.DataSource = _ListCircleAttendanceDetail;
            }
            else
            {
                dgv_ReportData.DataSource = _ListStudentAttendanceDetail;
            }
            _FillAttendanceReportCards();
        }
        void _LoadReport(string btnName)
        {
            switch(btnName)
            {
                case nameof(btn_AttendanceReports):
                    _LoadAttendanceReport();
                    break;
            }
        }
        private void _RefreshReportList()
        {
            _LoadReport(_CurrentReportBtn.Name);
            _FormatDataGridView();
            lbl_PageNumbering.Text = $"{(_TotalPages == 0?0:_CurrentPage)}/{_TotalPages}";
        }
        private void buttons_Click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                if (btn == _CurrentReportBtn) return;
                _ChangeBtnsColor(btn);
                _HandleReportCardsText(btn.Name);
            }
        }
        private void UC_Reports_Load(object sender, EventArgs e)
        {
            InitializeGridView();
            _ChangeBtnsColor(btn_AttendanceReports);
        }
        private void btn_GenarateReport_Click(object sender, EventArgs e)
        {
            _RefreshReportList();
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_CurrentPage >= _TotalPages) return;
            _CurrentPage++;
            _RefreshReportList();
            btn_Next.Enabled = _CurrentPage < _TotalPages;
            btn_Previous.Enabled = true;
        }
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (_CurrentPage <= 1) return;
            _CurrentPage--;
            _RefreshReportList();
            btn_Previous.Enabled = _CurrentPage > 1;
            btn_Next.Enabled = true;
        }
        private void dtp_DateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtp_DateTo.MinDate = dtp_DateFrom.Value;
        }
        private void lbl_PageNumbering_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && _TotalPages > 0)
            {
                NumUpDo_CurrrentPage.Visible = true;
                NumUpDo_CurrrentPage.Value = _CurrentPage;
                NumUpDo_CurrrentPage.Maximum = _TotalPages;
                lbl_PageNumbering.Visible = false;
            }
        }
        private void NumUpDo_CurrrentPage_Leave(object sender, EventArgs e)
        {
            NumUpDo_CurrrentPage.Visible = false;
            lbl_PageNumbering.Visible = true;
            if (_CurrentPage != NumUpDo_CurrrentPage.Value)
            {
                _CurrentPage = Convert.ToInt16(NumUpDo_CurrrentPage.Value);
                _RefreshReportList();
            }
        }
        private void NumUpDo_CurrrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NumUpDo_CurrrentPage_Leave(null, null);
            }
        }
        private void NumUpDo_CurrrentPage_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(NumUpDo_CurrrentPage.Value.ToString());
        }
        private void cmb_ReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsLodding) return;
            cmb_Students.Visible = _CurrentReportType == clsReports.enReportType.OneStudent;
            lb_Students.Visible = cmb_Students.Visible;
            _HandelItemAllCirclesInComboBox(_CurrentReportType);
            cmb_Circles_SelectedIndexChanged(null, null);
            if(_CurrentReportBtn == btn_AttendanceReports)
            {
                _HandleReportCard1TextInAttendanceReports();
            }
        }
        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_Students.Visible && int.TryParse(cmb_Circles.SelectedValue.ToString(), out int circleID) && circleID > 0)
            {
                _LoadStudentData();
                _FillStudentsInComoboBox();
            }
        }
    }
}
