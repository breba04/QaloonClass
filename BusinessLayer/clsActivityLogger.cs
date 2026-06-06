using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    static public class clsActivityLogger
    {
        static  clsActivityLogger()
        {
            clsEventManager.ActivityAdded += HandleActivity;
        }
        static public void HandleActivity(object sendor,clsEntityActivityLog EntityActivity)
        {
            clsActivityLoggerDataAccess.AddActivityLog(EntityActivity);
        }
        static int AddActivityLog(clsEntityActivityLog EntityActivity)
        {
            return clsActivityLoggerDataAccess.AddActivityLog( EntityActivity);
        }
        static public bool DeleteActivityLog(int ActivityID)
        {
            return clsActivityLoggerDataAccess.DeleteActivityLog(ActivityID);
        }
    }
}
