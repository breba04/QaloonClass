using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.GlobalClasses;

namespace UI.Users
{
    public class clsCurrentUser
    {
        static public clsUsers CurrentUser { get; set; }
        static public void Login(bool isRemember,string Notes = null)
        {
            if(CurrentUser == null )
            {
                return;
            }

            clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails()
            {
                UserID = CurrentUser.UserID,
                LoginDate = DateTime.Now,
                IsRemember = isRemember,
                Notes = Notes
            };

            if (isRemember)
                clsGlobal.StoreUserNameAndPassWordInRegistry(CurrentUser.UserName,CurrentUser.Password);

                clsLoginDetails.AddLoginDetails(loginDetails);
        }
        static public void LogOut()
        {
            CurrentUser = new clsUsers();
        }
    }
}
