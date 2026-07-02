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
        DataTable dtStudentList;
        DataTable dtAttendanceListToday;
        DataTable _dtCircles;
        bool IsNotTakenAttendanceToday;
        bool _IsLoading;
        public US_AttendanceMangement()
        {
            InitializeComponent();
            IsNotTakenAttendanceToday = true;
            _IsLoading = true;
        }
        private void _SetAllPresent()
        {
            foreach (DataGridViewRow row in dgvAttandenceList.Rows)
            {
                var Cell = row.Cells["Status"];
                Cell.Tag = 1;
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
        void Initialize_UC()
        {
            _IsLoading = true;
            _LoadCirclesData();
            _FillCirclesInComoboBox();
            _IsLoading = false;
            cmb_Circles.SelectedIndex = 0;
            dgvAttandenceList.AutoGenerateColumns = false;
            GetAttendanceData();
        }
        void InitializeGrivdView()
        {
            clsUtil.InitializeGridViewStyle(dgvAttandenceList);
        }
        void GetAttendanceData()
        {
            if(IsNotTakenAttendanceToday)
            {
                LoadStudentsDataFromDB();
                dgvAttandenceList.DataSource = dtStudentList;
                InitializeGrivdView();
            }
            else
            {

            }
        }
        void LoadStudentsDataFromDB()
        {
            dtStudentList = clsAttendance.SelectAllStudentsForAttendance((int)cmb_Circles.SelectedValue);
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
            _SetAllPresent();
        }
        private void dgvAttandenceList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex == dgvAttandenceList.ColumnCount - 1)
            {
                byte CurrentStatus = 1;
                if (byte.TryParse(dgvAttandenceList.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag?.ToString()
                    , out CurrentStatus)){ }
                Color color = CurrentStatus == 2 ? ColorTranslator.FromHtml("#BA1A1A")
                    : CurrentStatus == 3? ColorTranslator.FromHtml("#F59E0B")
                    : ColorTranslator.FromHtml("#16A34A");
                
                e.PaintBackground(e.CellBounds, false); //الغاء الرسم الافتراضي
                int diameter = 16; // قطر الدائرة

                Rectangle rect = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - diameter) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - diameter) / 2,
                    diameter, diameter);
                using (Brush brush = new SolidBrush(color)) // اللون
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // لجعل الحواف ناعمة
                    e.Graphics.FillEllipse(brush, rect); // رسم الدائرة الملونة
                }
                e.Handled = true;
            }
        }
        private void dgvAttandenceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != dgvAttandenceList.ColumnCount - 1 
                || (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)) return;

            DataGridViewCell cell = dgvAttandenceList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            byte CurrentStatus = Convert.ToByte(cell.Tag);
            cell.Tag = e.Button == MouseButtons.Right ? 3 :
                CurrentStatus == 1 ? 2 : 1;
            dgvAttandenceList.InvalidateCell(cell);
        }
        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsLoading) return;
            GetAttendanceData();
        }
        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {

        }
        private void btn_SetAllAttendance_Click(object sender, EventArgs e)
        {
            _SetAllPresent();
            dgvAttandenceList.InvalidateColumn(dgvAttandenceList.ColumnCount - 1);
        }
    }
}
