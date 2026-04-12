using BusinessLayer;
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
using UI.UserControls;
using UI.Users;

namespace UI
{
    public partial class frmMain : BaseForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        void LoadMainData()
        {
            lbl_FirstAndLastName.Text = clsCurrentUser.CurrentUser.UserData.UserName;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadMainData();
            this.HeaderTitle = $"مركز {clsGlobal.CenterName}";
            UC_Dashboard Dashboard = new UC_Dashboard();
            ShowControl(Dashboard);
        }

        private void ShowControl(Control control)
        {
            pnl_Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnl_Content.Controls.Add(control);
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dashboard");
        }

        private void btn_Student_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student");
        }

        private void btn_MemorizationCircle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Memorization Circle");
        }

        private void btn_Presence_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Presence");
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
            MessageBox.Show("Add New Student");
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            clsCurrentUser.LogOut();
            this.Close();
        }
    }
}
