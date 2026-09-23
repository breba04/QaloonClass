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
        private  Button _CurrentReportBtn => btn_AttendanceReports.BackColor == _ClickedBackColor? btn_AttendanceReports 
            : btn_GlobelReports.BackColor == _ClickedBackColor? btn_GlobelReports 
            : btn_StudentsReports;
        clsReports _AttendanceReports;
        List<clsEntityAttandanceReports.clsAttendanceDetail> _ListAttendanceDetail => _AttendanceReports.AttendanceDetail;
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
        }

        private void _FillAttendanceReportCards()
        {
            if(_AttendanceReports != null)
            {
                lb_CenterTitleCard1.Text = _AttendanceReports.TotalStudentNumbers.ToString();
                lb_CenterTitleCard2.Text = _AttendanceReports.TotalPresentDays.ToString();
                lb_CenterTitleCard3.Text = _AttendanceReports.TotalAbsentDays.ToString();
                lb_CenterTitleCard4.Text = $"{_AttendanceReports.AttendancePercentage:F2}%";
            }
        }
        private void _FormatDataGridViewColumnAttendanceReport()
        {
            if (dgv_ReportData.Columns.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["FullName"], "اسم الطالب", 220);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["CircleName"], "الحلقة", 150);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["TeacherName"], "المعلم", 150);

                clsUtil.ConfigureColumn(dgv_ReportData.Columns["TotalPresent"], "حضور", 90);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["TotalAbsent"], "غياب", 90);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["TotalExcusedAbsent"], "غياب بإذن", 110);

                clsUtil.ConfigureColumn(dgv_ReportData.Columns["AttendancePercentage"], "نسبة الحضور", 110);
                clsUtil.ConfigureColumn(dgv_ReportData.Columns["StudentStatus"], "الحالة", 120);
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
            dtp_DateFrom.MaxDate = DateTime.Now.Date;
            dtp_DateTo.MaxDate = DateTime.Now.Date;
            dtp_DateTo.MinDate = dtp_DateFrom.Value;
            dtp_DateFrom.Value = DateTime.Now.Date.AddMonths(-1);
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
            _TotalPages = _AttendanceReports.GenarateAttandanceReport(-1, dtp_DateFrom.Value, dtp_DateTo.Value, _CurrentPage, 10);
            dgv_ReportData.DataSource = _ListAttendanceDetail;
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
    }
}
