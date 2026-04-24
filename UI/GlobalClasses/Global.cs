using Microsoft.Win32;
using System;
namespace UI.GlobalClasses
{
    public class clsGlobal
    {
        static public string CenterName = "نور";

        static public string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\ABDULBASITAndIbrahim\TahfezCenter_System";

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
    }
}
