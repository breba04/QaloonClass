using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsLoginDetailsDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public bool AddLoginDetails
        (clsEntityclsLoginDetails LoginDetails)
        {
            bool isAdded = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertLoginDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginDate", LoginDetails.LoginDate);
                    cmd.Parameters.AddWithValue("@UserID", LoginDetails.UserID);
                    cmd.Parameters.AddWithValue("@IsRemember", LoginDetails.IsRemember);
                    cmd.Parameters.AddWithValue("@Notes", (object)LoginDetails.Notes ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                        {
                            LoginDetails.LoginID = Convert.ToInt32(obj);
                            isAdded = true;
                        }



                    }
                    catch (Exception Ex)
                    {

                    }
                }
            }
            return isAdded;
        }


        static public bool UpdateLoginDetails
        (clsEntityclsLoginDetails LoginDetails)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateLoginDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", LoginDetails.LoginID);
                    cmd.Parameters.AddWithValue("@UserID", LoginDetails.UserID);
                    cmd.Parameters.AddWithValue("@IsRemember", LoginDetails.IsRemember);
                    cmd.Parameters.AddWithValue("@LoginDate", LoginDetails.LoginDate);
                    cmd.Parameters.AddWithValue("@Notes", (object)LoginDetails.Notes ?? DBNull.Value);

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


        static public bool DeleteLoginDetails
        (int loginid)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteLoginDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", loginid);

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


        static public DataTable SelectAllLoginDetailss
        ()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllLoginDetailss", conn))
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
        static public bool FindLoginDetailsByID(clsEntityclsLoginDetails LoginDetailsData)
        {
            bool IsFound = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_GetLastLoginDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime, 10).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@IsRemember", SqlDbType.Bit, 10).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                            LoginDetailsData.UserID = Convert.ToInt32(cmd.Parameters["@UserID"].Value);
                            LoginDetailsData.LoginDate = Convert.ToDateTime(cmd.Parameters["@LoginDate"].Value);
                            LoginDetailsData.IsRemember = Convert.ToBoolean(cmd.Parameters["@IsRemember"].Value);
                            LoginDetailsData.Notes = cmd.Parameters["@Notes"].Value.ToString();
                        }

                    }
                    catch (Exception Ex)
                    {
                        clsLogger.AddLogToDB(Ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, " Login(clsEntityUser user)", DateTime.Now, null);
                    }
                }
                return IsFound;
            }
        }

        static public DataTable SelectLoginDetailsBy
        (int loginid)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectLoginDetailsBy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", loginid);

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


        static public bool IsLoginDetailsExist
        (int loginid)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsLoginDetailsExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", loginid);

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
