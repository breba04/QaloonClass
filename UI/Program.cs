using EntityLayer;
using System;
using System.Windows.Forms;
using UI.Login;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (clsCurrentUser.CurrentUser == null)
            {

                frmLogin loginForm = new frmLogin();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {

                    Application.Run(new frmMain());
                }
                else
                {
                    break;
                }
            }

            //Application.Run(new frmMain());
            // Application.Run(new frmAddAndUpdateStudent());
            //Application.Run(new BaseForm());
        }
    }
}
