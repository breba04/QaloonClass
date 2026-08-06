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
using UI.Attendance.UserControls;
using UI.Evaluations;
using UI.GlobalClasses;
using UI.Students;
using UI.Students.StudentControls;
using UI.UserControls;

namespace UI
{
    public partial class frmMain : BaseForm
    {
       private UC_Dashboard _Dashboard = null;
        public frmMain()
        {
            InitializeComponent();
        }
        void LoadMainData()
        {
            lbl_FirstAndLastName.Text = $"{clsCurrentUser.CurrentUser.FirstName} {clsCurrentUser.CurrentUser.LastName}";
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            _Dashboard = new UC_Dashboard();
            LoadMainData();
            this.HeaderTitle = $"مركز {clsGlobal.CenterName}";
            ShowControl(_Dashboard);
        }

        private void ShowControl(Control control)
        {
            pnl_Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnl_Content.Controls.Add(control);
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            ShowControl(_Dashboard);
        }

        private void btn_Student_Click(object sender, EventArgs e)
        {
            UC_Student Student = new UC_Student();
            ShowControl(Student);
        }
        

        private void btn_MemorizationCircle_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_AddEvaluation(UC_AddEvaluation.enMode.Add));
        }

        private void btn_Presence_Click(object sender, EventArgs e)
        {
            ShowControl(new US_AttendanceMangement());
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports");
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings");
        }

        private void btn_AddNewStudent_Click(object sender, EventArgs e)
        {
           frmAddAndUpdateStudent addStudentForm = new frmAddAndUpdateStudent();
            addStudentForm.ShowDialog();

            if (pnl_Content.Controls.Count > 0 && pnl_Content.Controls[0] == _Dashboard)
            {
                _Dashboard.RefreshDashboard();
            }

        }
 
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            clsCurrentUser.LogOut();
            this.Close();
        }
    }
}
