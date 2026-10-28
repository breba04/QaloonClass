using EntityLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUtilBusiness
    {
        public static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\ABDULBASITAndIbrahim\TahfezCenter_System";
        public static string GetExceptionMassege(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2:
                case 53:
                    return "تعذر الاتصال بخادم قاعدة البيانات. تأكد من أن السيرفر يعمل ومن اتصال الشبكة.";

                case 4060:
                    return "قاعدة البيانات المطلوبة غير موجودة على الخادم.";

                case 18456:
                    return "فشل تسجيل الدخول إلى قاعدة البيانات (خطأ في اسم المستخدم أو كلمة المرور).";

                case 2601:
                case 2627:
                    return "تعذر إتمام العملية بسبب تكرار إحدى البيانات.";

                case 547:
                    return "تعذر إتمام العملية بسبب ارتباط البيانات بسجلات أخرى.";

                case 515:
                    return "تعذر إتمام العملية لعدم توفير إحدى البيانات المطلوبة.";

                default:
                    return "حدث خطأ في قاعدة البيانات أثناء تنفيذ العملية " ;
            }
        }
        public static void StoreUserNameAndPassWordInRegistry(string UserName, string Password)
        {
            try
            {
                Registry.SetValue(KeyPath, "UserName", UserName);
                Registry.SetValue(KeyPath, "Password", Password);
            }
            catch (Exception ex)
            {
                clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.Business,
                    "StoreUserNameAndPassWordInRegistry", DateTime.Now);
            }
        }
    }
}
