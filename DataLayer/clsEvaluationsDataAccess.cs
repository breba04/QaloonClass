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
                    cmd.Parameters.AddWithValue("@EvalType", EntityEvaluation.EvalType);
                    cmd.Parameters.AddWithValue("@EvalDate", EntityEvaluation.EvalDate);
                    cmd.Parameters.AddWithValue("@IsEvaluationTaken", EntityEvaluation.IsEvaluationTaken);
                    cmd.Parameters.AddWithValue("@Rate", EntityEvaluation.Rate == null?DBNull.Value : (object)EntityEvaluation.Rate);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(EntityEvaluation.Notes)?DBNull.Value:(object)EntityEvaluation.Notes);

                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            result = Convert.ToInt32(obj);
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
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
                    cmd.Parameters.AddWithValue("@EvalDate", EntityEvaluation.EvalType);
                    cmd.Parameters.AddWithValue("@IsEvaluationTaken", EntityEvaluation.IsEvaluationTaken);
                    cmd.Parameters.AddWithValue("@Rate", EntityEvaluation.Rate == null ? DBNull.Value : (object)EntityEvaluation.Rate);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(EntityEvaluation.Notes) ? DBNull.Value : (object)EntityEvaluation.Notes);
                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "UpdateEvaluation", DateTime.Now, null);
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
                                                clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public DataTable SelectAllEvaluations(DateTime From,DateTime To)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllEvaluations", conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate",From);
                    cmd.Parameters.AddWithValue("@ToDate",To);
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
            }
            return result;
        }
        
        static public DataTable SelectAllTestType()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllTestType", conn))
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
                        clsLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
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
                                                clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool FindEvaluation(clsEntityEvaluation evaluation)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FindEvaluationByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", evaluation.StudentID);
                    cmd.Parameters.Add("@FromAyahID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ToAyahID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@EvalDate", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@EvalType", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = cmd.Parameters["@ReturnValue"].Value != DBNull.Value && Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value) > 0;
                        if (result)
                        {
                            evaluation.StudentID = Convert.ToInt32(cmd.Parameters["@StudentID"].Value);
                            evaluation.FromAyahID = Convert.ToInt16(cmd.Parameters["@FromAyahID"].Value);
                            evaluation.ToAyahID = Convert.ToInt16(cmd.Parameters["@ToAyahID"].Value);
                            evaluation.EvalDate = Convert.ToDateTime(cmd.Parameters["@EvalDate"].Value);
                            evaluation.EvalType = Convert.ToByte(cmd.Parameters["@EvalDate"].Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "FindEvaluation", DateTime.Now, null);
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
                                                clsLogger.AddLogToDB(ex.Message, -1, clsLogger.enLogType.Error, clsLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
    }
}