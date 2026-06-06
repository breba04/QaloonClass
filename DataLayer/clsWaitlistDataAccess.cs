using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsWaitlistDataAccess
    {


        static public int AddWaitlist(clsEntityWaitlist entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_InsertWaitlist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", entity.SecondName);
                cmd.Parameters.AddWithValue("@ThirdName", entity.ThirdName);
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
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
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }

        static public bool UpdateWaitlist(clsEntityWaitlist entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateWaitlist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", entity.SecondName);
                cmd.Parameters.AddWithValue("@ThirdName", entity.ThirdName);
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
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
                catch (Exception ex)
                {
                                            clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result > 0;
        }
        static public DataTable SelectAllWaitlist()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_SelectAllWaitlists", conn))
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
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }
        public static bool DeleteWaitlist(int WaitlistID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

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

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                catch (Exception ex)
                {
                                            clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }
        static public int TransferFromWaitlistToStudent(int waitlistId,int CircleID, string ImagePath)
        {
            int StudentID = -1;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_TransferFromWaitlistToStudent", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WaitlistID", waitlistId);
                cmd.Parameters.AddWithValue("@CircleID", CircleID);
                cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out StudentID)) { }
                }
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "TransferFromWaitlistToStudent", DateTime.Now, null);
                }
            }
            return StudentID;
        }
        static public byte GetNumberStudentsWating()
        {
            byte NumberStudentsWating = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetNumberStudentsWating", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumberStudentsWating", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    NumberStudentsWating = Convert.ToByte(cmd.Parameters["@NumberStudentsWating"].Value);
                }
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetNumberStudentsWating", DateTime.Now, null);
                }
            }
            return NumberStudentsWating;
        }
    }
}