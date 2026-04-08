using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class clsSettingsDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static public int AddSettings(clsEntitySettings entitySettings)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertSettings", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SettingID", entitySettings.SettingID);
                    cmd.Parameters.AddWithValue("@SettingKey", entitySettings.SettingKey);
                    cmd.Parameters.AddWithValue("@SettingValue", entitySettings.SettingValue);
                    cmd.Parameters.AddWithValue("@Notes", (object)entitySettings.Notes ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                         clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool UpdateSettings(clsEntitySettings entitySettings)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateSettings", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SettingID", entitySettings.SettingID);
                    cmd.Parameters.AddWithValue("@SettingKey", entitySettings.SettingKey);
                    cmd.Parameters.AddWithValue("@SettingValue", entitySettings.SettingValue);
                    cmd.Parameters.AddWithValue("@Notes", (object)entitySettings.Notes ?? DBNull.Value);

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
        static public string GetSettingsValue(string settingKey)
        {
            string settingValue = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetSettingValue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SettingKey", settingKey);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            settingValue = obj.ToString();
                    }
                    catch (Exception ex)
                    {
                                                clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return settingValue;
        }
        static public bool DeleteSettings(int settingID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteSettings", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SettingID", settingID);

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
    }
}