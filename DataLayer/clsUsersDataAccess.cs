
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
    }
}
