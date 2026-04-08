
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
        static public int AddUsers
        (clsEntityUser EntityUser)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", EntityUser.UserName);
                    cmd.Parameters.AddWithValue("@Password", EntityUser.Password);
                    cmd.Parameters.AddWithValue("@FullName", EntityUser.FullName);
                    cmd.Parameters.AddWithValue("@UserRole", EntityUser.UserRole);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);


                    }
                    catch (Exception Ex)
                    {
                        //ErrorHandler
                    }
                }
            }
            return result;
        }
        static public bool UpdateUsers
        (clsEntityUser EntityUser)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", EntityUser.UserID);
                    cmd.Parameters.AddWithValue("@UserName", EntityUser.UserName);
                    cmd.Parameters.AddWithValue("@Password", EntityUser.Password);
                    cmd.Parameters.AddWithValue("@FullName", EntityUser.FullName);
                    cmd.Parameters.AddWithValue("@UserRole", EntityUser.UserRole);

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
            {

                using (SqlCommand cmd = new SqlCommand("SP_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar,10).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@UserRole", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
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
                            user.FullName = cmd.Parameters["@FullName"].Value.ToString();
                            user.UserRole = Convert.ToInt32(cmd.Parameters["@UserRole"].Value);
                            user.UserID = Convert.ToInt32(cmd.Parameters["@UserID"].Value);
                        }
                        
                    }
                    catch (Exception Ex)
                    {
                        clsLogger.AddLogToDB(Ex.Message,-1,clsLogger.enLogType.Error,clsLogger.enLogLevel.DataLayer, " Login(clsEntityUser user)", DateTime.Now,null);
                    }
                }
                return IsLogin;
            }
        }
        static public bool FindByUserID(clsEntityUser user)
        {
            bool IsLogin = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_FindByUserID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.Add("@UserName" , SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar,100).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@UserRole", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
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
                            user.UserName = cmd.Parameters["@UserName"].Value.ToString();
                            user.Password = cmd.Parameters["@Password"].Value.ToString();
                            user.FullName = cmd.Parameters["@FullName"].Value.ToString();
                            user.UserRole = Convert.ToInt32(cmd.Parameters["@UserRole"].Value);
                            user.UserID = Convert.ToInt32(cmd.Parameters["@UserID"].Value);
                        }
                        
                    }
                    catch (Exception Ex)
                    {
                        clsLogger.AddLogToDB(Ex.Message,-1,clsLogger.enLogType.Error,clsLogger.enLogLevel.DataLayer, " Login(clsEntityUser user)", DateTime.Now,null);
                    }
                }
                return IsLogin;
            }
        }
    }
}
