using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class clsActivityLoggerDataAccess
    {

        static public int AddActivityLog(clsEntityActivityLog EntityActivity)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertActivityLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionType", EntityActivity.ActionType);
                    cmd.Parameters.AddWithValue("@EntityID", EntityActivity.EntityID);
                    cmd.Parameters.AddWithValue("@EntityType", EntityActivity.EntityType);
                    cmd.Parameters.AddWithValue("@Description", EntityActivity.Description);
                    cmd.Parameters.AddWithValue("@ActivityDate", EntityActivity.ActivityDate);
                    cmd.Parameters.AddWithValue("@UserID", EntityActivity.UserID);
                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "AddActivityLog", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool DeleteActivityLog(int ActivityID)
        {
            bool IsDeleted = default;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteActivityLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityID", ActivityID);
                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out int result))
                            IsDeleted = result == 1;
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteActivityLog", DateTime.Now, null);
                    }
                }
            }
            return IsDeleted;
        }
    }
}
