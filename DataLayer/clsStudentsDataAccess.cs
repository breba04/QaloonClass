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

                cmd.Parameters.AddWithValue("@FirstName", entity.PersonInfo.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", entity.PersonInfo.SecodName);
                cmd.Parameters.AddWithValue("@ThirdName", (object)entity.PersonInfo.ThirdName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", entity.PersonInfo.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.PersonInfo.BirthDate);
                cmd.Parameters.AddWithValue("@Address", entity.PersonInfo.Address);
                cmd.Parameters.AddWithValue("@IsActive", entity.PersonInfo.IsActive);

                cmd.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("@JoinDate", entity.JoinDate);
                cmd.Parameters.AddWithValue("@CircleID", entity.CircleID);

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = Convert.ToInt32(obj);
                }
                catch (Exception ex)
                {
                    clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "AddStudent", DateTime.Now, null);
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

                cmd.Parameters.AddWithValue("@FirstName", entity.PersonInfo.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", entity.PersonInfo.SecodName);
                cmd.Parameters.AddWithValue("@ThirdName", (object)entity.PersonInfo.ThirdName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", entity.PersonInfo.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.PersonInfo.BirthDate);
                cmd.Parameters.AddWithValue("@Address", entity.PersonInfo.Address);
                cmd.Parameters.AddWithValue("@IsActive", entity.PersonInfo.IsActive);

                cmd.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("@JoinDate", entity.JoinDate);
                cmd.Parameters.AddWithValue("@CircleID", entity.CircleID);

                try
                {
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "UpdateStudent", DateTime.Now, null);
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
                catch (Exception ex)
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

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@ParentPhone", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@JoinDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CircleID", SqlDbType.Int).Direction = ParameterDirection.Output;

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();

                    if (obj != null)
                    {
                        student.PersonInfo.FirstName = cmd.Parameters["@FirstName"].Value.ToString();
                        student.PersonInfo.SecodName = cmd.Parameters["@SecondName"].Value.ToString();

                        student.PersonInfo.LastName = cmd.Parameters["@LastName"].Value.ToString();
                        student.PersonInfo.BirthDate = Convert.ToDateTime(cmd.Parameters["@BirthDate"].Value);
                        student.PersonInfo.IsActive = Convert.ToBoolean(cmd.Parameters["@IsActive"].Value);

                        student.ParentPhone = cmd.Parameters["@ParentPhone"].Value.ToString();
                        student.JoinDate = Convert.ToDateTime(cmd.Parameters["@JoinDate"].Value);
                        student.CircleID = Convert.ToInt32(cmd.Parameters["@CircleID"].Value);

                        if (cmd.Parameters["@ThirdName"].Value != DBNull.Value)
                            student.PersonInfo.ThirdName = cmd.Parameters["@ThirdName"].Value.ToString(); 
                        if (cmd.Parameters["@Address"].Value != DBNull.Value)
                            student.PersonInfo.Address = cmd.Parameters["@Address"].Value.ToString();


                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "FindStudentByID", DateTime.Now, null);
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
                catch (Exception ex)
                {
                                            clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                }
            }
            return result;
        }
        static public short GetNewStudentsStatsLastMonth()
        {
            short result = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetNewStudentsStatsLastMonth", conn))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetNewStudentsStatsLastMonth", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public short GetTotalStudentAbsent(DateTime FromDate,DateTime ToDate)
        {
            short result = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetTotalStudentAbsent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.Add("@CountAbsent",SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlParameter parameter = new SqlParameter();
                    parameter.Direction = ParameterDirection.Output;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        if (cmd.Parameters["@CountAbsent"].Value != null)
                            result = Convert.ToInt16(cmd.Parameters["@CountAbsent"].Value);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetTotalStudentAbsent", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
    }
}