using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsStudentsDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public int AddStudent(clsEntityStudent entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_InsertStudents", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                cmd.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("@Address", entity.Address);
                cmd.Parameters.AddWithValue("@JoinDate", entity.JoinDate);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@CircleID", entity.CircleID);

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

        static public bool UpdateStudent(clsEntityStudent entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateStudents", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", entity.StudentID);
                cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                cmd.Parameters.AddWithValue("@@BirthDate", entity.BirthDate);
                cmd.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("@Address", entity.Address);
                cmd.Parameters.AddWithValue("@JoinDate", entity.JoinDate);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@CircleID", entity.CircleID);

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
        static public bool DeleteStudent(int StudentID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(_connectionString);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteStudents", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);

                    try
                    {
                        connection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }

            }

            return (rowsAffected > 0);
        }
        static public bool IsStudentExist(int studentId)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_IsStudentExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", studentId);

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
        static public bool FindStudentByID(clsEntityStudent student)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_FindStudentByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ParentPhone", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@JoinDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CircleID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        student.FullName = cmd.Parameters["@FullName"].Value.ToString();
                        student.BirthDate = Convert.ToDateTime(cmd.Parameters["@BirthDate"].Value);
                        student.ParentPhone = cmd.Parameters["@ParentPhone"].Value.ToString();
                        student.Address = cmd.Parameters["@Address"].Value.ToString();
                        student.JoinDate = Convert.ToDateTime(cmd.Parameters["@JoinDate"].Value);
                        student.CircleID = Convert.ToInt32(cmd.Parameters["@CircleID"].Value);
                        result = Convert.ToBoolean(obj);
                    }
                }
                catch (Exception Ex)
                {
                                            clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }
        static public DataTable SelectAllStudents()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_SelectAllStudents", conn))
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
    }
}