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
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public DataTable GetAllSurrah()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                    clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetAllSurrah", DateTime.Now, null);
                }
            }
            return result;
        }
        static public DataTable GetAllAyatFromSurrah(byte SurrahNo)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllAyatFromSurrah", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SurrahNo", SurrahNo);
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
                    clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "GetAllAyatFromSurrah", DateTime.Now, null);
                }
            }
            return result;
        }
    }
}
