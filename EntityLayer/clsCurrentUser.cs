using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCurrentUser
    {
        static public clsEntityUser CurrentUser { get; set; }

        static public void LogOut()
        {
            CurrentUser = null;
        }
    }
}
