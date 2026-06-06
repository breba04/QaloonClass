using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsStudentProgressDataAccess
    {


        static public int AddProgress(clsEntityStudentProgress EntityProgress)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertStudentProgress", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", EntityProgress.StudentID);
                    cmd.Parameters.AddWithValue("@AyahID", EntityProgress.AyahID);
                    cmd.Parameters.AddWithValue("@UpdateDate", EntityProgress.UpdateDate);
                    cmd.Parameters.AddWithValue("@TeacherID", EntityProgress.TeacherID);

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
            }
            return result;
        }

        static public bool UpdateProgress(clsEntityStudentProgress EntityProgress)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateStudentProgress", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgressID", EntityProgress.ProgressID);
                    cmd.Parameters.AddWithValue("@StudentID", EntityProgress.StudentID);
                    cmd.Parameters.AddWithValue("@AyahID", EntityProgress.AyahID);
                    cmd.Parameters.AddWithValue("@UpdateDate", EntityProgress.UpdateDate);
                    cmd.Parameters.AddWithValue("@TeacherID", EntityProgress.TeacherID);

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

        static public bool DeleteProgress(int progressID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteStudentProgress", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgressID", progressID);

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

        static public DataTable SelectAllProgress()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllStudentProgress", conn))
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
            }
            return result;
        }

        static public DataTable SelectProgressBy(int progressID)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectStudentProgressBy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgressID", progressID);

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
            }
            return result;
        }

        static public bool IsProgressExist(int progressID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsStudentProgressExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgressID", progressID);

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
            }
            return result;
        }
        static public bool FindProgressByStudentID (clsEntityStudentProgress progress)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_FindProgressByStudentID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", progress.StudentID);

                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SurrahID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@AyahID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;

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

                        progress.TeacherID = Convert.ToInt32(cmd.Parameters["@TeacherID"].Value);
                        progress.SurrahID = Convert.ToByte(cmd.Parameters["@SurrahID"].Value);
                        progress.AyahID = Convert.ToInt16(cmd.Parameters["@AyahID"].Value);
                        progress.UpdateDate = Convert.ToDateTime(cmd.Parameters["@UpdateDate"].Value);
                    }
                }
                catch (Exception Ex)
                {
                    clsErrorLogger.AddLogToDB(Ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "FindProgressByStudentID", DateTime.Now, null);
                }
            }

            return IsFound;
        }

    }
}