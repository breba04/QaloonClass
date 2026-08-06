using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
using DataLayer;

namespace DataAccessLayer
{
    public class clsEvaluationsDataAccess
    {


        static public int AddEvaluation(clsEntityEvaluation EntityEvaluation)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public bool UpdateEvaluation(clsEntityEvaluation EntityEvaluation)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateEvaluation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EvaluationID", EntityEvaluation.EvaluationID);
                    cmd.Parameters.AddWithValue("@StudentID", EntityEvaluation.StudentID);
                    cmd.Parameters.AddWithValue("@FromAyahID", EntityEvaluation.FromAyahID);
                    cmd.Parameters.AddWithValue("@ToAyahID", EntityEvaluation.ToAyahID);
                    cmd.Parameters.AddWithValue("@EvalDate", EntityEvaluation.EvalDate);
                    cmd.Parameters.AddWithValue("@EvalType", EntityEvaluation.EvalType);
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
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "UpdateEvaluation", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public bool DeleteEvaluation(int evaluationID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                                                clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result > 0;
        }

        static public DataTable SelectAllEvaluationsTaken(DateTime From,DateTime To)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllEvaluationsTaken", conn))
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        
        static public DataTable SelectAllEvaluationsNotTaken()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SelectAllEvaluationsNotTaken", conn))
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
                        clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "SelectAllEvaluationsNotTaken", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        
        static public DataTable SelectAllTestType()
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }

        static public DataTable SelectEvaluationBy(int evaluationID)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                                                clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public bool FindEvaluation(clsEntityEvaluation evaluation)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FindEvaluationByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluation.EvaluationID);
                    cmd.Parameters.Add("@StudentID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@FromAyahID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ToAyahID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@EvalDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@EvalType", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@IsEvaluationTaken", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Rate", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar,-1).Direction = ParameterDirection.Output;
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
                            evaluation.IsEvaluationTaken = Convert.ToBoolean(cmd.Parameters["@IsEvaluationTaken"].Value);
                            evaluation.EvalDate = Convert.ToDateTime(cmd.Parameters["@EvalDate"].Value);
                            evaluation.EvalType = (clsEntityEvaluation.enEvaluationType)Convert.ToByte(cmd.Parameters["@EvalType"].Value);
                            evaluation.Rate =(clsEntityEvaluation.enRate)Convert.ToByte(cmd.Parameters["@Rate"].Value);
                            evaluation.Notes = Convert.ToString(cmd.Parameters["@Notes"].Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "FindEvaluation", DateTime.Now, null);
                    }
                }
            }
            return result;
        }               
        static public bool IsEvaluationExist(int evaluationID)
        {
            bool result = default(Boolean);

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
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
                                                clsErrorLogger.AddLogToDB(ex.Message, -1, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "DeleteCircle", DateTime.Now, null);
                    }
                }
            }
            return result;
        }
        static public int GetNumberOfStudentsNotTakeEvaluationInMonth()
        {
            int NumberOfStudents = 0;

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetNumberOfStudentsNotTakeEvaluationInMonth", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumberOfStudentsNotTakeEvaluation", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    NumberOfStudents = Convert.ToInt32(cmd.Parameters["@NumberOfStudentsNotTakeEvaluation"].Value);
                }
                catch (Exception ex)
                {
                    clsErrorLogger.AddLogToDB(ex.Message, clsCurrentUser.CurrentUser.UserID, clsErrorLogger.enLogType.Error, clsErrorLogger.enLogLevel.DataLayer, "GetNumberOfStudentsNotTakeEvaluationInMonth", DateTime.Now, null);
                }
            }
            return NumberOfStudents;
        }

    }
}