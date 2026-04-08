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
using UI.Users;

namespace UI.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.Login(txt_UserName.Text,txt_PassWord.Text);
            if (User == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }
            clsCurrentUser.Login(User,ckb_RememberMe.Checked);
            if(!ckb_RememberMe.Checked)
            {
                txt_UserName.Text = "";
                txt_PassWord.Text = "";
            }
            frmMain frm = new frmMain();
            frm.Show();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsCurrentUser.CurrentUser = clsLoginDetails.GetLastLoginUser();
            if (clsCurrentUser.CurrentUser != null)
            {
                txt_UserName.Text = clsCurrentUser.CurrentUser.UserData.UserName;
                txt_PassWord.Text = clsCurrentUser.CurrentUser.UserData.Password;
                ckb_RememberMe.Checked = true;
            }
        }
    }
}
