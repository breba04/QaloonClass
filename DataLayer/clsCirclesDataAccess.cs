using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsCirclesDataAccess
    {


        static public int AddCircle(clsEntityCircle EntityCircle)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertCircle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleName", EntityCircle.CircleName);
                    cmd.Parameters.AddWithValue("@TeacherID", EntityCircle.TeacherID);
                    cmd.Parameters.AddWithValue("@MaxCapacity", EntityCircle.MaxCapacity);
                    cmd.Parameters.AddWithValue("@ScheduleType", EntityCircle.ScheduleType);

                    cmd.Parameters.AddWithValue("@StartTime", EntityCircle.StartTime.HasValue?
                        (object)EntityCircle.StartTime.Value.TimeOfDay: DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@PrayerID", EntityCircle.PrayerID.HasValue? 
                        (object)EntityCircle.PrayerID :DBNull.Value);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "AddCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool UpdateCircle(clsEntityCircle EntityCircle)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateCircles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", EntityCircle.CircleID);
                    cmd.Parameters.AddWithValue("@CircleName", EntityCircle.CircleName);
                    cmd.Parameters.AddWithValue("@TeacherID", EntityCircle.TeacherID);
                    cmd.Parameters.AddWithValue("@MaxCapacity", EntityCircle.MaxCapacity);

                    cmd.Parameters.AddWithValue("@ScheduleType", EntityCircle.ScheduleType);

                    cmd.Parameters.AddWithValue("@StartTime", EntityCircle.StartTime.HasValue ?
                       (object)EntityCircle.StartTime.Value.TimeOfDay : DBNull.Value);

                    cmd.Parameters.AddWithValue("@PrayerID", EntityCircle.PrayerID.HasValue ?
                        (object)EntityCircle.PrayerID : DBNull.Value);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "UpdateCircle", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }
        static public bool DeleteCircle(int circleID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteCircle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", circleID);

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
            }
            return result > 0;
        }
        static public DataTable SelectAllCircles()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllCircless", conn))
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "SelectAllCircles", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public DataTable SelectCircleBy(int circleID)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectCircleBy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", circleID);

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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "SelectCircleBy", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool FindCircleByID(clsEntityCircle Circle)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_FindByCircleID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CircleID", Circle.CircleID);

                cmd.Parameters.Add("@CircleName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@TeacherID", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MaxCapacity", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ScheduleType", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@PrayerID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CurrentStudentNumbers", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlParameter ReturnValue = new SqlParameter();
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ReturnValue);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    int Result = Convert.ToInt32(ReturnValue.Value);

                    if (Result == 1)
                    {
                        IsFound = true;

                        Circle.CircleName = cmd.Parameters["@CircleName"].Value.ToString();
                        Circle.TeacherID = Convert.ToInt32(cmd.Parameters["@TeacherID"].Value);
                        Circle.MaxCapacity = Convert.ToByte(cmd.Parameters["@MaxCapacity"].Value);
                        Circle.CurrentStudentNumbers = Convert.ToByte(cmd.Parameters["@CurrentStudentNumbers"].Value);
                        Circle.CircleID = Convert.ToInt32(cmd.Parameters["@CircleID"].Value);

                        Circle.ScheduleType = (clsEntityCircle.enScheduleType)Convert.ToByte(cmd.Parameters["@ScheduleType"].Value);

                        Circle.PrayerID = cmd.Parameters["@PrayerID"].Value != DBNull.Value?
                            Convert.ToByte(cmd.Parameters["@PrayerID"].Value)
                            : (byte?)null;

                        Circle.StartTime = cmd.Parameters["@StartTime"].Value != DBNull.Value?
                            Convert.ToDateTime(cmd.Parameters["@StartTime"].Value)
                            : (DateTime?)null;
                    }
                }
                catch (Exception Ex)
                {
                    clsErrorLogger.AddLogToDB(Ex.Message, clsCurrentUser.CurrentUser==null?-1: clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "FundCircleByID", DateTime.Now, null);
                }
            }

            return IsFound;
        }
        static public bool IsCircleExist(int circleID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsCircleExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", circleID);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToBoolean(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "IsCircleExist", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool AddingSeatsInCircle(int circleID,byte CountSeats)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddingSeatsInCircle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", circleID);
                    cmd.Parameters.AddWithValue("@CountSeats", @CountSeats);
                    cmd.Parameters.Add("@ReturnValue",SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        if(cmd.Parameters["@ReturnValue"].Value != null && int.TryParse(cmd.Parameters["@ReturnValue"].Value.ToString(), out int returnValue))
                        {
                            result = Convert.ToBoolean(returnValue);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "AddingSeatsInCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public DataTable GetAllCircleView(byte PageNo,byte RecordInPage)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllCircleView", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNo", PageNo);
                    cmd.Parameters.AddWithValue("@RecordsInPage", RecordInPage);
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetAllCircleView", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public byte GetTotalPagesRecordsInCircleView(byte RecordInPage)
        {
            byte result = 0;
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetTotalPagesRecordsInCircleView", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RecordsInPage", RecordInPage);
                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToByte(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetNewCirclesStatsLastMonth", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public short GetNewCirclesStatsLastMonth()
        {
            short result = 0;
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetNewCirclesStatsLastMonth", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt16(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetNewCirclesStatsLastMonth", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public byte GetRemainingSeatsInClass(int CircleID)
        {
            byte result = 0;
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetRemainingSeatsInClass", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", CircleID);
                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToByte(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetRemainingSeatsInClass", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public int GetSupervisorByCircleID(int CircleID)
        {
            int TeacherID = -1;
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetSupervisorByCircleID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", CircleID);
                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            TeacherID = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetSupervisorByCircleID", DateTime.Now, null);
                    }
                }
            }
            return TeacherID;
        }
        static public DataTable GetllEpisodesTeacher(int TeacherID)
        {
            DataTable Circles = new DataTable ();
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetllEpisodesTeacher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader Reader = cmd.ExecuteReader())
                        {
                            Circles.Load(Reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message,clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetllEpisodesTeacher", DateTime.Now, null);
                    }
                }
            }
            return Circles;
        }
        static public byte GetNumberOfAvailableSeats()
        {
            byte NumberOfAvailableSeats = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetNumberOfAvailableSeats", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumberOfAvailableSeats", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    NumberOfAvailableSeats = Convert.ToByte(cmd.Parameters["@NumberOfAvailableSeats"].Value);
                }
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetNumberOfAvailableSeats", DateTime.Now, null);
                }
            }
            return NumberOfAvailableSeats;
        }

    }
}