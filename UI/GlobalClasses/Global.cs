using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;
namespace UI.GlobalClasses
{
    public class clsGlobal
    {
        static public string CenterName = "نور";

        static public string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\ABDULBASITAndIbrahim\TahfezCenter_System";
        static public string ImageFolder = Path.Combine(Application.StartupPath,"Student_Image");

        static public  void StoreUserNameAndPassWordInRegistry(string UserName ,string Password)
        {
            try
            {
                 Registry.SetValue(clsGlobal.KeyPath, "UserName", UserName);
                 Registry.SetValue(clsGlobal.KeyPath, "Password", Password);
            }
            catch (Exception ex)
            {
                // Errors will be recorded in the LOG file later.

            }
        }
        static public  void ShowSeccesMessgae(string message,string title)
        {
            MessageBox.Show(message,title,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        static public  void ShowErrorMessgae(string message,string title)
        {
            MessageBox.Show(message,title,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        
    }
}
