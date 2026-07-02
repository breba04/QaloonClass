using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsAttendanceDataAccess
    {

        static public int AddAttendance(clsEntityAttendance EntityAttendance)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                        clsErrorLogger.AddLogToDB(ex.Message ,-1,clsErrorLogger.enLogType.Error,clsErrorLogger.enLogLevel.DataLayer, "AddAttendance", DateTime.Now,null);
                    }
                }
            }
            return result;
        }
        static public bool UpdateAttendance(clsEntityAttendance EntityAttendance)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "UpdateAttendance", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }
        static public bool DeleteAttendance(int attendanceID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteAttendance", DateTime.Now, null);

                    }
                }
            }
            return result > 0;
        }
        static public DataTable SelectAllAttendances(int CircleID,DateTime Date)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllAttendances", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", CircleID);
                    cmd.Parameters.AddWithValue("@Date", Date);
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
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "SelectAllAttendances", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public DataTable SelectAllAttendancesStatus()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllAttendancesStatus", conn))
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
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "SelectAllAttendancesStatus", DateTime.Now, null);

                    }
                }
            }
            return result;
        }
        static public DataTable SelectAllStudentsForAttendance(int CircleID)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllStudentsForAttendance", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", CircleID);
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
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "SelectAllStudentsForAttendance", DateTime.Now, null);

                    }
                }
            }
            return result;
        }
        static public bool IsAttendanceExist(int attendanceID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "IsAttendanceExist", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool IsAttendanceExistsToday(int CircleID)
        {
            bool isExist = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsAttendanceExistsToday", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", CircleID);
                    cmd.Parameters.Add("@ReturnValue",SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        object obj = cmd.Parameters["@ReturnValue"].Value;
                        if (obj != null && int.TryParse(obj.ToString(),out int result))
                            isExist = Convert.ToBoolean(result);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "IsAttendanceExist", DateTime.Now, null);
                    }
                }
            }
            return isExist;
        }

        static public bool FindAttendanceByStudentID(clsEntityAttendance Attendance)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_FindAttendanceByStudentID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", Attendance.StudentID);
                cmd.Parameters.Add("@AttendanceID", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@AttendanceDate", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    object obj = cmd.Parameters["@ReturnValue"].Value;

                    if (obj != null && int.TryParse(obj.ToString(), out int ReturnValue) && ReturnValue == 1)
                    {
                        result = true;
                        Attendance.AttendanceID = Convert.ToInt32(cmd.Parameters["@AttendanceID"].Value);
                        Attendance.AttendanceDate = Convert.ToDateTime(cmd.Parameters["@AttendanceDate"].Value);
                        Attendance.Status = Convert.ToByte(cmd.Parameters["@Status"].Value);
                    }
                }
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "FindStudentByID", DateTime.Now, null);
                }
            }

            return result;
        }
    }
}