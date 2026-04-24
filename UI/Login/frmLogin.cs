using BusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using UI.GlobalClasses;
using UI.Users;

namespace UI.Login
{
    public partial class frmLogin : BaseForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ptcb_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        

        private void btn_Login_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                   "Validation Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                return;
            }


            if (_IsUserLoginSuccessful())
            {
                if (_IsUserActive())
                {
                    clsCurrentUser.Login( ckb_RememberMe.Checked);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your account is not active, please contact the administrator",
                        "Account Inactive",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password, please try again",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void _RetrieveRememberedData()
        {
            clsCurrentUser.CurrentUser = clsLoginDetails.GetLastLoginUser();
            if (clsCurrentUser.CurrentUser != null)
            {
                txt_UserName.Text = clsCurrentUser.CurrentUser.UserName;
                txt_PassWord.Text = clsCurrentUser.CurrentUser.Password;
                ckb_RememberMe.Checked = true;
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _RetrieveRememberedData();
            this.HeaderTitle = $"مركز {clsGlobal.CenterName}";
        }

        private bool _IsUserLoginSuccessful()
        {
            clsCurrentUser.CurrentUser  = clsUsers.Login(txt_UserName.Text, txt_PassWord.Text);
            return clsCurrentUser.CurrentUser != null;
        }
        private bool _IsUserActive()
        {
            return clsCurrentUser.CurrentUser.IsActive;
        }
        private void txt_Box_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox != null)
            {
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    errorProvider1.SetError(txtBox, $"{txtBox.Tag} مطلوب");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtBox, string.Empty);
                }
            }


        }
    }
}
