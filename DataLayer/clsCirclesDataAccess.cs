using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsCirclesDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public int AddCircle(clsEntityCircle EntityCircle)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertCircle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleName", EntityCircle.CircleName);
                    cmd.Parameters.AddWithValue("@TeacherID", EntityCircle.TeacherID);
                    cmd.Parameters.AddWithValue("@MaxCapacity", EntityCircle.MaxCapacity);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "AddCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public bool UpdateCircle(clsEntityCircle EntityCircle)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateCircle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircleID", EntityCircle.CircleID);
                    cmd.Parameters.AddWithValue("@CircleName", EntityCircle.CircleName);
                    cmd.Parameters.AddWithValue("@TeacherID", EntityCircle.TeacherID);
                    cmd.Parameters.AddWithValue("@MaxCapacity", EntityCircle.MaxCapacity);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "UpdateCircle", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public bool DeleteCircle(int circleID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public DataTable SelectAllCircles()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllCircles", conn))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "SelectAllCircles", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public DataTable SelectCircleBy(int circleID)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "SelectCircleBy", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public bool IsCircleExist(int circleID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "IsCircleExist", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public DataTable GetAllCircleView(byte PageNo,byte RecordInPage)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetAllCircleView", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public byte GetTotalPagesRecordsInCircleView(byte RecordInPage)
        {
            byte result = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetNewCirclesStatsLastMonth", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public short GetNewCirclesStatsLastMonth()
        {
            short result = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetNewCirclesStatsLastMonth", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
    }
}