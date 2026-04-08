using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLoginDetails
    {

        static public bool AddLoginDetails(clsEntityclsLoginDetails LoginDetailsData)
        {
            return clsLoginDetailsDataAccess.AddLoginDetails(LoginDetailsData);
        }
        static public clsUsers GetLastLoginUser()
        {
            clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails();
            if (clsLoginDetailsDataAccess.FindLoginDetailsByID(loginDetails))
            {
                if (loginDetails.IsRemember)
                {
                    return clsUsers.Find(loginDetails.UserID);
                }
            }
            return null;
        }

    }
}
