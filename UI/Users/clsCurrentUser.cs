using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Users
{
    public class clsCurrentUser
    {
        static public clsUsers CurrentUser { get; set; }
        static public void Login(clsUsers user,bool isRemember,string Notes = null)
        {
            CurrentUser = user;
            clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails()
            {
                UserID = user.UserData.UserID,
                LoginDate = DateTime.Now,
                IsRemember = isRemember,
                Notes = Notes
            };
            clsLoginDetails.AddLoginDetails(loginDetails);
        }
        static public void LogOut()
        {
            CurrentUser = new clsUsers();
        }
    }
}
