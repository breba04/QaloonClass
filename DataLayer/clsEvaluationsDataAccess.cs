using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class clsEvaluationsDataAccess
    {
        static private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static public int AddEvaluation(clsEntityEvaluation EntityEvaluation)
        {
            int result = default(Int32);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertEvaluation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", EntityEvaluation.StudentID);
                    cmd.Parameters.AddWithValue("@FromAyahID", EntityEvaluation.FromAyahID);
                    cmd.Parameters.AddWithValue("@ToAyahID", EntityEvaluation.ToAyahID);
                    cmd.Parameters.AddWithValue("@EvalDate", EntityEvaluation.EvalDate);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "AddEvaluation", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public bool UpdateEvaluation(clsEntityEvaluation EntityEvaluation)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateEvaluation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EvaluationID", EntityEvaluation.EvaluationID);
                    cmd.Parameters.AddWithValue("@StudentID", EntityEvaluation.StudentID);
                    cmd.Parameters.AddWithValue("@FromAyahID", EntityEvaluation.FromAyahID);
                    cmd.Parameters.AddWithValue("@ToAyahID", EntityEvaluation.ToAyahID);
                    cmd.Parameters.AddWithValue("@EvalDate", EntityEvaluation.EvalDate);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "UpdateEvaluation", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public bool DeleteEvaluation(int evaluationID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DeleteEvaluation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluationID);

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteEvaluation", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public DataTable SelectAllEvaluations()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllEvaluations", conn))
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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "SelectAllEvaluations", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public DataTable SelectEvaluationBy(int evaluationID)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectEvaluationBy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluationID);

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
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "SelectEvaluationBy", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public bool IsEvaluationExist(int evaluationID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_IsEvaluationExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluationID);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToBoolean(obj);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "IsEvaluationExist", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
    }
}