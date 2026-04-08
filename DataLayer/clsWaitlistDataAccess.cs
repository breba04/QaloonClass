using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsWaitlistDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public int AddWaitlist(clsEntityWaitlist entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_InsertWaitlist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                cmd.Parameters.AddWithValue("@Age", entity.Age);
                cmd.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("@Address", entity.Address);
                cmd.Parameters.AddWithValue("@RegistrationDate", entity.RegistrationDate);
                cmd.Parameters.AddWithValue("@Notes", entity.Notes);
                cmd.Parameters.AddWithValue("@IsAdded", entity.IsAdded);

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = Convert.ToInt32(obj);
                }
                catch (Exception Ex)
                {
                                            clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }

        static public bool UpdateWaitlist(clsEntityWaitlist entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateWaitlist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WaitlistID", entity.WaitlistID);
                cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                cmd.Parameters.AddWithValue("@Age", entity.Age);
                cmd.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("@Address", entity.Address);
                cmd.Parameters.AddWithValue("@RegistrationDate", entity.RegistrationDate);
                cmd.Parameters.AddWithValue("@Notes", entity.Notes);
                cmd.Parameters.AddWithValue("@IsAdded", entity.IsAdded);

                try
                {
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                                            clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result > 0;
        }

        static public DataTable SelectAllWaitlist()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_SelectAllWaitlist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
                catch (Exception Ex)
                {
                                            clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }
        public static bool DeleteWaitlist(int WaitlistID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"DELETE Waitlist 
                     WHERE WaitlistID = @WaitlistID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@WaitlistID", WaitlistID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        static public bool IsWaitlistExist(int waitlistId)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_IsWaitlistExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WaitlistID", waitlistId);

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = Convert.ToBoolean(obj);
                }
                catch (Exception Ex)
                {
                                            clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }
    }
}