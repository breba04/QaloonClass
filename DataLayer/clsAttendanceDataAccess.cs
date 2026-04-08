using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsAttendanceDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public int AddAttendance(clsEntityAttendance EntityAttendance)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertAttendance", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", EntityAttendance.StudentID);
                    cmd.Parameters.AddWithValue("@AttendanceDate", EntityAttendance.AttendanceDate);
                    cmd.Parameters.AddWithValue("@Status", EntityAttendance.Status);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message ,-1,clsLogger.enLogType.Error,clsLogger.enLogLevel.DataLayer, "AddAttendance", DateTime.Now,null);
                    }
                }
            }
            return result;
        }

        static public bool UpdateAttendance(clsEntityAttendance EntityAttendance)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateAttendance", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttendanceID", EntityAttendance.AttendanceID);
                    cmd.Parameters.AddWithValue("@StudentID", EntityAttendance.StudentID);
                    cmd.Parameters.AddWithValue("@AttendanceDate", EntityAttendance.AttendanceDate);
                    cmd.Parameters.AddWithValue("@Status", EntityAttendance.Status);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "UpdateAttendance", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public bool DeleteAttendance(int attendanceID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteAttendance", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttendanceID", attendanceID);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteAttendance", DateTime.Now, null);

                    }
                }
            }
            return result > 0;
        }

        static public DataTable SelectAllAttendances()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllAttendances", conn))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "SelectAllAttendances", DateTime.Now, null);

                    }
                }
            }
            return result;
        }
        static public bool IsAttendanceExist(int attendanceID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsAttendanceExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttendanceID", attendanceID);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToBoolean(obj);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "IsAttendanceExist", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
    }
}