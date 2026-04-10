
/***************Users****************/

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
namespace DataAccessLayer
{
    public class clsUsersDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static public int AddUsers(clsEntityUser EntityUser)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_InsertUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", EntityUser.UserName);
                cmd.Parameters.AddWithValue("@Password", EntityUser.Password);
                cmd.Parameters.AddWithValue("@UserRole", EntityUser.UserRole);

                cmd.Parameters.AddWithValue("@FirstName", EntityUser.PersonInfo.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", EntityUser.PersonInfo.SecodName);
                cmd.Parameters.AddWithValue("@ThirdName", (object)EntityUser.PersonInfo.ThirdName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", EntityUser.PersonInfo.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", EntityUser.PersonInfo.BirthDate);
                cmd.Parameters.AddWithValue("@Address", (object)EntityUser.PersonInfo.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", EntityUser.PersonInfo.IsActive);

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = Convert.ToInt32(obj);
                }
                catch (Exception Ex)
                {
                    clsLogger.AddLogToDB(Ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "AddUsers", DateTime.Now, null);
                }
            }
            return result;
        }
        static public bool UpdateUsers(clsEntityUser EntityUser)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", EntityUser.UserID);
                cmd.Parameters.AddWithValue("@UserName", EntityUser.UserName);
                cmd.Parameters.AddWithValue("@Password", EntityUser.Password);
                cmd.Parameters.AddWithValue("@UserRole", EntityUser.UserRole);

                cmd.Parameters.AddWithValue("@FirstName", EntityUser.PersonInfo.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", EntityUser.PersonInfo.SecodName);
                cmd.Parameters.AddWithValue("@ThirdName",(object) EntityUser.PersonInfo.ThirdName??DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", EntityUser.PersonInfo.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", EntityUser.PersonInfo.BirthDate);
                cmd.Parameters.AddWithValue("@Address", (object)EntityUser.PersonInfo.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", EntityUser.PersonInfo.IsActive);

                try
                {
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    clsLogger.AddLogToDB(Ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "UpdateUsers", DateTime.Now, null);
                }
            }
            return result > 0;
        }
        static public bool DeleteUsers
        (int userid)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userid);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();

                    }
                    catch (Exception Ex)
                    {
                        //ErrorHandler
                    }
                }
            }
            return result > 0;
        }
        static public DataTable SelectAllUserss
        ()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllUserss", conn))
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
                        //ErrorHandler
                    }
                }
            }
            return result;
        }
        static public DataTable SelectUsersBy
        (int userid)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectUsersBy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userid);

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
                        //ErrorHandler
                    }
                }
            }
            return result;
        }
        static public bool IsUsersExist
        (int userid)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsUsersExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userid);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToBoolean(obj);


                    }
                    catch (Exception Ex)
                    {
                        //ErrorHandler
                    }
                }
            }
            return result;
        }

        static public bool Login(clsEntityUser user)
        {
            bool IsLogin = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_Login", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UserRole", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Direction = ParameterDirection.Output;

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
                        IsLogin = true;

                        user.UserID = Convert.ToInt32(cmd.Parameters["@UserID"].Value);
                        user.UserRole = Convert.ToInt32(cmd.Parameters["@UserRole"].Value);

                        user.PersonInfo.FirstName = cmd.Parameters["@FirstName"].Value.ToString();
                        user.PersonInfo.SecodName = cmd.Parameters["@SecondName"].Value.ToString();
                        user.PersonInfo.LastName = cmd.Parameters["@LastName"].Value.ToString();
                        user.PersonInfo.BirthDate = Convert.ToDateTime(cmd.Parameters["@BirthDate"].Value);
                        user.PersonInfo.Address = cmd.Parameters["@Address"].Value.ToString();
                        user.PersonInfo.IsActive = Convert.ToBoolean(cmd.Parameters["@IsActive"].Value);
                        
                        if (cmd.Parameters["@ThirdName"].Value != DBNull.Value)
                            user.PersonInfo.ThirdName = cmd.Parameters["@ThirdName"].Value.ToString();
                        if (cmd.Parameters["@Address"].Value != DBNull.Value)
                            user.PersonInfo.Address = cmd.Parameters["@Address"].Value.ToString();
                    }
                }
                catch (Exception Ex)
                {
                    clsLogger.AddLogToDB(Ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "Login", DateTime.Now, null);
                }
            }

            return IsLogin;
        }
        static public bool FindByUserID(clsEntityUser user)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_FindByUserID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", user.UserID);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UserRole", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Direction = ParameterDirection.Output;

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

                        user.UserName = cmd.Parameters["@UserName"].Value.ToString();
                        user.Password = cmd.Parameters["@Password"].Value.ToString();
                        user.UserRole = Convert.ToInt32(cmd.Parameters["@UserRole"].Value);

                        user.PersonInfo.FirstName = cmd.Parameters["@FirstName"].Value.ToString();
                        user.PersonInfo.SecodName = cmd.Parameters["@SecondName"].Value.ToString();
                        user.PersonInfo.LastName = cmd.Parameters["@LastName"].Value.ToString();
                        user.PersonInfo.BirthDate = Convert.ToDateTime(cmd.Parameters["@BirthDate"].Value);
                        user.PersonInfo.Address = cmd.Parameters["@Address"].Value.ToString();
                        user.PersonInfo.IsActive = Convert.ToBoolean(cmd.Parameters["@IsActive"].Value);

                        if (cmd.Parameters["@ThirdName"].Value != DBNull.Value)
                            user.PersonInfo.ThirdName = cmd.Parameters["@ThirdName"].Value.ToString();
                        if (cmd.Parameters["@Address"].Value != DBNull.Value)
                            user.PersonInfo.Address = cmd.Parameters["@Address"].Value.ToString();
                    }
                }
                catch (Exception Ex)
                {
                    clsLogger.AddLogToDB(Ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "FindByUserID", DateTime.Now, null);
                }
            }

            return IsFound;
        }
    }
    }

