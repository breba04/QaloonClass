using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GlobalClasses;
using UI.Login;
using UI.Students;

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
