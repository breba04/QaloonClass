using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GlobalClasses;

namespace UI.Attendance.UserControls
{
    public partial class US_AttendanceMangement : UserControl
    {
        DataTable _dtStudentList;
        DataTable _dtAttendanceListToday;
        DataTable _dtCircles;
        bool _IsTakenAttendanceToday;
        bool _IsLoading;
        clsAttendance _AttendanceStudent;
        HashSet<int> _ChangedStudents;
        List<clsAttendance> _ListStudent;
        public US_AttendanceMangement()
        {
            InitializeComponent();
            _IsTakenAttendanceToday = false;
            _IsLoading = true;
            _ListStudent = new List<clsAttendance>();
        }
        void _AddToChangedStudentsHash(int StudentID)
        {
            if (_ChangedStudents == null)
                _ChangedStudents = new HashSet<int>();
            _ChangedStudents.Add(StudentID);
        }
        private void _SetAllPresent()
        {
            foreach (DataGridViewRow row in dgvAttandenceList.Rows)
            {
                var Cell = row.Cells["Status"];
                Cell.Value = 1;

            }
        }
        private void _LoadCirclesData()
        {
            _dtCircles = clsCircles.SelectAllCirclesMiniData();
            DataRow row = _dtCircles.NewRow();
            row["CircleID"] = -1;
            row["CircleName"] = "كل الحلقات";
            _dtCircles.Rows.InsertAt(row, 0);
        }
        public void _FillCirclesInComoboBox()
        {
            if (_dtCircles != null && _dtCircles.Rows.Count > 0)
            {
                cmb_Circles.DataSource = _dtCircles;
                cmb_Circles.DisplayMember = "CircleName";
                cmb_Circles.ValueMember = "CircleID";
            }
        }
        public Color _GetColorToDrawCircle(byte Status)
        {
            return Status == 2 ? ColorTranslator.FromHtml("#BA1A1A")
                    : Status == 3 ? ColorTranslator.FromHtml("#F59E0B")
                    : ColorTranslator.FromHtml("#16A34A");

        }
        public string _GetStatusName(byte Status)
        {
            return Status == 2 ? "غائب"
                    : Status == 3 ? "بعذر"
                    : "حاضر";
        }
        public void _DrawCircleInCell(DataGridViewCellPaintingEventArgs e,  int diameter)
        {

            byte CurrentStatus = 1;
            if (byte.TryParse(dgvAttandenceList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()
                , out CurrentStatus)) { }
            Rectangle rect = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - diameter) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - diameter) / 2,
                    diameter, diameter);
            Color color = _GetColorToDrawCircle(CurrentStatus);
            using (Brush brush = new SolidBrush(color)) 
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // لجعل الحواف ناعمة
                e.Graphics.FillEllipse(brush, rect); // رسم الدائرة الملونة
            }
        }
        public void _DrawTextInCell(DataGridViewCellPaintingEventArgs e,  float MarginX)
        {

            byte CurrentStatus = 1;
            if (byte.TryParse(dgvAttandenceList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()
                , out CurrentStatus)) { }

            string Text = _GetStatusName(CurrentStatus);
            using (Brush brush = new SolidBrush(Color.Black)) 
            {
                float x = e.CellBounds.X + MarginX;
                float y = e.CellBounds.Y + (e.CellBounds.Height - e.Graphics.MeasureString(Text, dgvAttandenceList.Font).Height) / 2;
                e.Graphics.DrawString(Text, dgvAttandenceList.Font, brush,x , y);
            }
        }
        void Initialize_cmbCircles()
        {
            _LoadCirclesData();
            _FillCirclesInComoboBox();
            cmb_Circles.SelectedIndex = 0;
        }
        void InitializeGrivdView()
        {
            dgvAttandenceList.AutoGenerateColumns = false;
            clsUtil.InitializeGridViewStyle(dgvAttandenceList);
            GetAttendanceData();
        }
        void DisplayTitleForTakenOrNotTakenAttendance()
        {
            if (!_IsTakenAttendanceToday)
            {
                lbTakenAttendanceToday.Text = "لم يتم تسجيل حضور الطلبة اليوم";
                lbTakenAttendanceToday.ForeColor = ColorTranslator.FromHtml("#BA1A1A");
            }
            else
            {
                lbTakenAttendanceToday.Text = " تم تسجيل حضور الطلبة اليوم";
                lbTakenAttendanceToday.ForeColor = ColorTranslator.FromHtml("#16A34A");
            }
        }
        void Initialize_UC()
        {
            _IsLoading = true;
            Initialize_cmbCircles();
            _IsLoading = false;
            _IsTakenAttendanceToday = clsAttendance.IsAttendanceExistsToday((int)cmb_Circles.SelectedValue);

            InitializeGrivdView();
            DisplayTitleForTakenOrNotTakenAttendance();

        }
        void GetAttendanceData()
        {
            if(_IsTakenAttendanceToday)
            {
                LoadAttendanceTodayDataFromDB();
                if (_dtAttendanceListToday != null && _dtAttendanceListToday.Rows.Count > 0)
                {
                    dgvAttandenceList.Columns["Status"].DataPropertyName = "Status";
                    dgvAttandenceList.DataSource = _dtAttendanceListToday;
                }
            }
            else
            {
                LoadStudentsDataFromDB();
                if(_dtStudentList != null && _dtStudentList.Rows.Count > 0)
                    dgvAttandenceList.DataSource = _dtStudentList;
                
            }
        }
        void LoadStudentsDataFromDB()
        {
            _dtStudentList = clsAttendance.SelectAllStudentsForAttendance((int)cmb_Circles.SelectedValue);
        }
        void LoadAttendanceTodayDataFromDB()
        {
            _dtAttendanceListToday = clsAttendance.SelectAllAttendancesToday((int)cmb_Circles.SelectedValue);
            _dtAttendanceListToday.Columns["Status"].ReadOnly = false;
        }
        void FillAttendanceObject(DataGridViewRow row)
        {
            if (row.IsNewRow || row.Cells.Count == 0) return;

            int _StudentID = Convert.ToInt32(row.Cells["StudentID"].Value);

            _AttendanceStudent = (_IsTakenAttendanceToday)? clsAttendance.Find(_StudentID) 
                : new clsAttendance();

            _AttendanceStudent.StudentID = _StudentID;
            _AttendanceStudent.AttendanceDate = DateTime.Today;
            _AttendanceStudent.CircleID = Convert.ToInt32(row.Cells["CircleID"].Value);
            _AttendanceStudent.Status = Convert.ToByte(row.Cells["Status"].Value);
        }
        void FillAttendanceList()
        {
            foreach (DataGridViewRow row in dgvAttandenceList.Rows)
            {
                if (row.IsNewRow || row.Cells.Count == 0 
                    || (_IsTakenAttendanceToday &&!_ChangedStudents.Contains(Convert.ToInt32(row.Cells["StudentID"].Value)))) 
                    continue;

                FillAttendanceObject(row);
                _ListStudent.Add(_AttendanceStudent);
            }
        } 
        private void US_AttendanceMangement_Load(object sender, EventArgs e)
        {
            Initialize_UC();
        }
        private void dgvAttandenceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvAttandenceList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_IsLoading) return;

            if (!_IsTakenAttendanceToday)
            {
                _IsLoading = true;
                _SetAllPresent();
                _IsLoading = false;
            }
        }
        private void dgvAttandenceList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex == dgvAttandenceList.ColumnCount - 1)
            {
                
                e.PaintBackground(e.CellBounds, false); //الغاء الرسم الافتراضي

                int diameter = 16;
                _DrawCircleInCell(e,diameter);
                
                _DrawTextInCell(e,diameter*2);
                
                e.Handled = true;
            }
        }
        private void dgvAttandenceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != dgvAttandenceList.ColumnCount - 1
                || (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)) return;

            DataGridViewCell cell = dgvAttandenceList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            byte CurrentStatus = Convert.ToByte(cell.Value);

            byte NextStatus = (byte)(e.Button == MouseButtons.Right ? 3 :
                CurrentStatus == 1 ? 2 : 1);

            cell.Value = NextStatus;

            if (_IsTakenAttendanceToday)
            {
                int StudentID = Convert.ToInt32(dgvAttandenceList.Rows[e.RowIndex].Cells["StudentID"].Value);
                _AddToChangedStudentsHash(StudentID);
            }

            dgvAttandenceList.InvalidateCell(cell);
        }
        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ListStudent != null)
                _ListStudent.Clear();
            if(_ChangedStudents != null)
                _ChangedStudents.Clear();
            if (_IsLoading) return;

            _IsTakenAttendanceToday = clsAttendance.IsAttendanceExistsToday((int)cmb_Circles.SelectedValue);
            GetAttendanceData();
            DisplayTitleForTakenOrNotTakenAttendance();
        }
        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dgvAttandenceList.DataSource as DataTable;
            if(dt == null) return;

            dt.DefaultView.RowFilter = string.IsNullOrEmpty(txt_SearchByName.Text) ? string.Empty
                : clsUtil.GetFilterExpression(dgvAttandenceList.Columns["FullName"].Name, clsUtil.enTypeOfFilter.String, txt_SearchByName.Text);

        }
        private void btn_SetAllAttendance_Click(object sender, EventArgs e)
        {
            _SetAllPresent();
            dgvAttandenceList.InvalidateColumn(dgvAttandenceList.ColumnCount - 1);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FillAttendanceList();
            if (_ListStudent.Count == 0)
            {
                MessageBox.Show("لم يتم إجراء أي تعديل على الحضور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsAttendance.AddAttendance(_ListStudent);
                MessageBox.Show("تم تسجيل الحضور بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Initialize_UC();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ جسيم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
