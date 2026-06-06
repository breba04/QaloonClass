using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsMoshafQaloonDataAccess
    {


        static public DataTable GetAllSurrah()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllSurrah", conn))
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
                    clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetAllSurrah", DateTime.Now, null);
                }
            }
            return result;
        }
        static public DataTable GetAlljazza()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetAlljazza", conn))
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
                    clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetAlljazza", DateTime.Now, null);
                }
            }
            return result;
        }
        static public DataTable GetAllAyatFromSurrah(byte SurrahNo,byte NumberOfLetters)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllAyatFromSurrah", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SurraID", SurrahNo);
                cmd.Parameters.AddWithValue("@NumberOfLetters", NumberOfLetters);
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
                    clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetAllAyatFromSurrah", DateTime.Now, null);
                }
            }
            return result;
        }
    }
}
