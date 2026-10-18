using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using DataAccessLayer;

namespace DataLayer
{
    public class clsReportsDataAccess
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CircleID">-1 => all Circles</param>
        /// <param name="PageNO">number of page</param>
        /// <param name="RecordsInPage">record in every page</param>
        static public (List<clsEntityAttandanceReports.clsCircleAttendanceDetail> AttendanceDetail, clsEntityAttandanceReports.clsCalculatedAttendance CalculatedAttendance) GetCircleAttandanceReport(
            int CircleID, DateTime DateFrom ,DateTime DateTo,short PageNO,byte RecordsInPage, ref short TotalPage, bool ReturnMainData)
        {
            List<clsEntityAttandanceReports.clsCircleAttendanceDetail> lst = new List<clsEntityAttandanceReports.clsCircleAttendanceDetail>();
            clsEntityAttandanceReports.clsCalculatedAttendance calculatedAttendance = new clsEntityAttandanceReports.clsCalculatedAttendance();
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_CircleAttendance", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CircleID", CircleID);
                        cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", DateTo);
                        cmd.Parameters.AddWithValue("@PageNO", PageNO);
                        cmd.Parameters.AddWithValue("@RecordsInPage", RecordsInPage);
                        cmd.Parameters.AddWithValue("@ReturnMainData", ReturnMainData);
                        cmd.Parameters.Add("@TotalPage",SqlDbType.SmallInt).Direction = ParameterDirection.Output;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lst.Add(new clsEntityAttandanceReports.clsCircleAttendanceDetail()
                                {
                                    FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : string.Empty,
                                    CircleName = reader["CircleName"] != DBNull.Value ? reader["CircleName"].ToString() : string.Empty,
                                    TeacherName = reader["TeacherName"] != DBNull.Value ? reader["TeacherName"].ToString() : string.Empty,
                                    TotalPresent = reader["TotalPresent"] != DBNull.Value ? Convert.ToInt16(reader["TotalPresent"]) :(short)0,
                                    TotalAbsent = reader["TotalAbsent"] != DBNull.Value ? Convert.ToInt16(reader["TotalAbsent"]) :(short)0,
                                    TotalExcusedAbsent = reader["TotalExcusedAbsent"] != DBNull.Value ? Convert.ToInt16(reader["TotalExcusedAbsent"]) :(short)0,
                                });
                            }
                            if(reader.NextResult())
                            {
                                if (reader.Read()) 
                                {
                                    calculatedAttendance.TotalPresentDays = reader["TotalPresentDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalPresentDays"]) : 0;
                                    calculatedAttendance.TotalAbsentDays = reader["TotalAbsentDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalAbsentDays"]) : 0;
                                    calculatedAttendance.TotalExcusedAbsentDays = reader["TotalExcusedAbsentDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalExcusedAbsentDays"]) : 0;
                                    calculatedAttendance.TotalStudentNumbers = reader["TotalStudentNumbers"] != DBNull.Value ? Convert.ToInt32(reader["TotalStudentNumbers"]) : 0;
                                }
                            }
                        }
                        object obj = cmd.Parameters["@TotalPage"].Value;
                        if (obj != null && short.TryParse(obj.ToString(), out TotalPage)) { }
                        

                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
           return (lst,calculatedAttendance);
        }

        
        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CircleID">-1 => all Circles</param>
        /// <param name="PageNO">number of page</param>
        /// <param name="RecordsInPage">record in every page</param>
        static public (List<clsEntityAttandanceReports.clsStudentAttendanceDetail> AttendanceDetail, clsEntityAttandanceReports.clsCalculatedAttendance CalculatedAttendance)
            GetStudentAttandanceReport(
            int StudentID, DateTime DateFrom ,DateTime DateTo,short PageNO,byte RecordsInPage, ref short TotalPage, bool ReturnMainData)
        {
            List<clsEntityAttandanceReports.clsStudentAttendanceDetail> lst = new List<clsEntityAttandanceReports.clsStudentAttendanceDetail>();
            clsEntityAttandanceReports.clsCalculatedAttendance calculatedAttendance = new clsEntityAttandanceReports.clsCalculatedAttendance();
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_StudentAttendance", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentID", StudentID);
                        cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", DateTo);
                        cmd.Parameters.AddWithValue("@PageNO", PageNO);
                        cmd.Parameters.AddWithValue("@RecordsInPage", RecordsInPage);
                        cmd.Parameters.AddWithValue("@ReturnMainData", ReturnMainData);
                        cmd.Parameters.Add("@TotalPage",SqlDbType.SmallInt).Direction = ParameterDirection.Output;

                        conn.Open();


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lst.Add(new clsEntityAttandanceReports.clsStudentAttendanceDetail()
                                {
                                    StatusName = reader["StatusName"] != DBNull.Value ? reader["StatusName"].ToString() : string.Empty,
                                    AttendanceDate = reader["AttendanceDate"] != DBNull.Value ? Convert.ToDateTime(reader["AttendanceDate"]).ToString("dd/MM/yyyy") : string.Empty,
                                    //Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : string.Empty,
                                });
                            }
                             if(reader.NextResult())
                            {
                                if (reader.Read()) 
                                {
                                    calculatedAttendance.TotalPresentDays = reader["TotalPresentDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalPresentDays"]) : 0;
                                    calculatedAttendance.TotalAbsentDays = reader["TotalAbsentDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalAbsentDays"]) : 0;
                                    calculatedAttendance.TotalExcusedAbsentDays = reader["TotalExcusedAbsentDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalExcusedAbsentDays"]) : 0;
                                }
                            }
                        }
                        object obj = cmd.Parameters["@TotalPage"].Value;
                        if (obj != null && short.TryParse(obj.ToString(), out TotalPage)) { }
                        

                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
           return (lst,calculatedAttendance);
        }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CircleID">-1 => all Circles</param>
        /// <param name="PageNO">number of page</param>
        /// <param name="RecordsInPage">record in every page</param>
        static public (List<clsEntityEvaluationReports.clsCircleEvaluationDetail> EvaluationDetail, clsEntityEvaluationReports.clsCalculatedStudentEvaluation CalculatedEvaluation)
            GetStudentEvaluation(
            int StudentID, DateTime DateFrom ,DateTime DateTo,short PageNO,byte RecordsInPage, ref short TotalPage, bool ReturnMainData, byte NumberOfLettersInAyaText)
        {
            List<clsEntityEvaluationReports.clsCircleEvaluationDetail> lst = new List<clsEntityEvaluationReports.clsCircleEvaluationDetail>();
            clsEntityEvaluationReports.clsCalculatedStudentEvaluation calculatedEvaluation = new clsEntityEvaluationReports.clsCalculatedStudentEvaluation();
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_StudentEvaluation", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentID", StudentID);
                        cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", DateTo);
                        cmd.Parameters.AddWithValue("@PageNO", PageNO);
                        cmd.Parameters.AddWithValue("@RecordsInPage", RecordsInPage);
                        cmd.Parameters.AddWithValue("@ReturnMainData", ReturnMainData);
                        cmd.Parameters.AddWithValue("@NumberOfLettersInAyaText", NumberOfLettersInAyaText);
                        cmd.Parameters.Add("@TotalPage",SqlDbType.SmallInt).Direction = ParameterDirection.Output;

                        conn.Open();


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lst.Add(new clsEntityEvaluationReports.clsCircleEvaluationDetail()
                                {
                                    FullName = reader["FullName"] != DBNull.Value
                                        ? reader["FullName"].ToString()
                                        : string.Empty,

                                    CircleName = reader["CircleName"] != DBNull.Value
                                        ? reader["CircleName"].ToString()
                                        : string.Empty,

                                    TeacherName = reader["TeacherName"] != DBNull.Value
                                        ? reader["TeacherName"].ToString()
                                        : string.Empty,

                                    EvaluationName = reader["EvaluationName"] != DBNull.Value
                                        ? reader["EvaluationName"].ToString()
                                        : string.Empty,

                                    EvaluationDate = reader["EvaluationDate"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["EvaluationDate"]).ToString("dd/MM/yyyy")
                                        : string.Empty,

                                    EvaluationRate = reader["EvaluationRate"] != DBNull.Value
                                        ? reader["EvaluationRate"].ToString()
                                        : string.Empty,

                                    EvaluationFromAya = reader["EvaluationFromAya"] != DBNull.Value
                                        ? reader["EvaluationFromAya"].ToString()
                                        : string.Empty,

                                    EvaluationToAya = reader["EvaluationToAya"] != DBNull.Value
                                        ? reader["EvaluationToAya"].ToString()
                                        : string.Empty,

                                    Notes = reader["Notes"] != DBNull.Value
                                        ? reader["Notes"].ToString()
                                        : string.Empty
                                });
                            }

                            if (reader.NextResult())
                            {
                                if (reader.Read())
                                {
                                    calculatedEvaluation.LastEvaluation =
                                        reader["LastEvaluation"] != DBNull.Value
                                            ? reader["LastEvaluation"].ToString()
                                            : string.Empty;

                                    calculatedEvaluation.TotalEvaluationNumbers =
                                        reader["TotalEvaluationNumbers"] != DBNull.Value
                                            ? Convert.ToInt32(reader["TotalEvaluationNumbers"])
                                            : 0;

                                    calculatedEvaluation.BestRate =
                                        reader["BestRate"] != DBNull.Value
                                            ? reader["BestRate"].ToString()
                                            : string.Empty;

                                    calculatedEvaluation.EvaluationAvrage =
                                        reader["EvaluationAvrage"] != DBNull.Value
                                            ? reader["EvaluationAvrage"].ToString()
                                            : string.Empty;
                                }
                            }
                        }
                        object obj = cmd.Parameters["@TotalPage"].Value;
                        if (obj != null && short.TryParse(obj.ToString(), out TotalPage)) { }
                        

                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
           return (lst, calculatedEvaluation);
        }
        
        
        
        /// <summary>
        /// Retrieves evaluation report details for a circle or all circles.
        /// </summary>
        /// <param name="CircleID">-1 => All Circles</param>
        /// <param name="PageNO">Number of page</param>
        /// <param name="RecordsInPage">Records in every page</param>
        static public (
            List<clsEntityEvaluationReports.clsCircleEvaluationDetail> EvaluationDetail,
            clsEntityEvaluationReports.clsCalculatedEvaluation CalculatedEvaluation)
            GetCircleEvaluation(
                int CircleID,
                DateTime DateFrom,
                DateTime DateTo,
                short PageNO,
                byte RecordsInPage,
                ref short TotalPage,
                bool ReturnMainData,
                byte NumberOfLettersInAyaText)
        {
            List<clsEntityEvaluationReports.clsCircleEvaluationDetail> lst =
                new List<clsEntityEvaluationReports.clsCircleEvaluationDetail>();

            clsEntityEvaluationReports.clsCalculatedEvaluation calculatedEvaluation =
                new clsEntityEvaluationReports.clsCalculatedEvaluation();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_CircleEvaluation", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CircleID", CircleID);
                        cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", DateTo);
                        cmd.Parameters.AddWithValue("@PageNO", PageNO);
                        cmd.Parameters.AddWithValue("@RecordsInPage", RecordsInPage);
                        cmd.Parameters.AddWithValue("@ReturnMainData", ReturnMainData);
                        cmd.Parameters.AddWithValue("@NumberOfLettersInAyaText", NumberOfLettersInAyaText);

                        cmd.Parameters.Add("@TotalPage", SqlDbType.SmallInt)
                            .Direction = ParameterDirection.Output;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lst.Add(new clsEntityEvaluationReports.clsCircleEvaluationDetail()
                                {
                                    FullName = reader["FullName"] != DBNull.Value
                                        ? reader["FullName"].ToString()
                                        : string.Empty,

                                    CircleName = reader["CircleName"] != DBNull.Value
                                        ? reader["CircleName"].ToString()
                                        : string.Empty,

                                    TeacherName = reader["TeacherName"] != DBNull.Value
                                        ? reader["TeacherName"].ToString()
                                        : string.Empty,

                                    EvaluationName = reader["EvaluationName"] != DBNull.Value
                                        ? reader["EvaluationName"].ToString()
                                        : string.Empty,

                                    EvaluationDate = reader["EvaluationDate"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["EvaluationDate"]).ToString("dd/MM/yyyy")
                                        : string.Empty,

                                    EvaluationRate = reader["EvaluationRate"] != DBNull.Value
                                        ? reader["EvaluationRate"].ToString()
                                        : string.Empty,

                                    EvaluationFromAya = reader["EvaluationFromAya"] != DBNull.Value
                                        ? reader["EvaluationFromAya"].ToString()
                                        : string.Empty,

                                    EvaluationToAya = reader["EvaluationToAya"] != DBNull.Value
                                        ? reader["EvaluationToAya"].ToString()
                                        : string.Empty,

                                    Notes = reader["Notes"] != DBNull.Value
                                        ? reader["Notes"].ToString()
                                        : string.Empty
                                });
                            }

                            if (reader.NextResult())
                            {
                                if (reader.Read())
                                {
                                    calculatedEvaluation.TotalStudentNumbers =
                                        reader["TotalStudentNumbers"] != DBNull.Value
                                            ? Convert.ToInt32(reader["TotalStudentNumbers"])
                                            : 0;

                                    calculatedEvaluation.TotalEvaluationNumbers =
                                        reader["TotalEvaluationNumbers"] != DBNull.Value
                                            ? Convert.ToInt32(reader["TotalEvaluationNumbers"])
                                            : 0;

                                    calculatedEvaluation.BestStudent =
                                        reader["BestStudent"] != DBNull.Value
                                            ? reader["BestStudent"].ToString()
                                            : string.Empty;

                                    calculatedEvaluation.EvaluationAvrage =
                                        reader["EvaluationAvrage"] != DBNull.Value
                                            ? reader["EvaluationAvrage"].ToString()
                                            : string.Empty;
                                }
                            }
                        }

                        object obj = cmd.Parameters["@TotalPage"].Value;

                        if (obj != null && obj != DBNull.Value)
                            short.TryParse(obj.ToString(), out TotalPage);
                    }
                    catch (Exception)
                    {
                        // يُفضّل تسجيل الخطأ بدل تجاهله بصمت.
                        throw;
                    }
                }
            }

            return (lst, calculatedEvaluation);
        }


        /// <summary>
        /// Retrieves comprehensive report details for a circle or all circles.
        /// </summary>
        /// <param name="CircleID">-1 => All Circles</param>
        /// <param name="Month">Selected month</param>
        /// <param name="Year">Selected year</param>
        /// <param name="PageNO">Number of page</param>
        /// <param name="RecordsInPage">Records in every page</param>
        static public (
            List<clsEntityComprehensiveReports.clsCircleComprehensiveDetail> ComprehensiveDetail,
            clsEntityComprehensiveReports.clsCalculatedCircleComprehensive CalculatedComprehensive)
            GetCircleComprehensive(
                int CircleID,
                byte Month,
                short Year,
                short PageNO,
                byte RecordsInPage,
                ref short TotalPage,
                bool ReturnMainData)
        {
            List<clsEntityComprehensiveReports.clsCircleComprehensiveDetail> lst =
                new List<clsEntityComprehensiveReports.clsCircleComprehensiveDetail>();

            clsEntityComprehensiveReports.clsCalculatedCircleComprehensive calculatedComprehensive =
                new clsEntityComprehensiveReports.clsCalculatedCircleComprehensive();

            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_CircleComprehensive", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CircleID", CircleID);
                        cmd.Parameters.AddWithValue("@Month", Month);
                        cmd.Parameters.AddWithValue("@Year", Year);
                        cmd.Parameters.AddWithValue("@PageNO", PageNO);
                        cmd.Parameters.AddWithValue("@RecordsInPage", RecordsInPage);
                        cmd.Parameters.AddWithValue("@ReturnMainData", ReturnMainData);

                        cmd.Parameters.Add("@TotalPage", SqlDbType.SmallInt)
                            .Direction = ParameterDirection.Output;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lst.Add(
                                    new clsEntityComprehensiveReports.clsCircleComprehensiveDetail()
                                    {
                                        FullName = reader["FullName"] != DBNull.Value
                                            ? reader["FullName"].ToString()
                                            : string.Empty,

                                        SeatsNumber = reader["SeatsNumber"] != DBNull.Value
                                            ? reader["SeatsNumber"].ToString()
                                            : string.Empty,

                                        CircleName = reader["CircleName"] != DBNull.Value
                                            ? reader["CircleName"].ToString()
                                            : string.Empty,

                                        TeacherName = reader["TeacherName"] != DBNull.Value
                                            ? reader["TeacherName"].ToString()
                                            : string.Empty,

                                        CurrentProgress = reader["CurrentProgress"] != DBNull.Value
                                            ? reader["CurrentProgress"].ToString()
                                            : "غير معرف",

                                        AttendancePercentage = reader["AttendancePercentage"] != DBNull.Value
                                            ? Convert.ToDecimal(reader["AttendancePercentage"])
                                            : 0.00m,

                                        LastEvaluation = reader["LastEvaluation"] != DBNull.Value
                                            ? reader["LastEvaluation"].ToString()
                                            : "لا يوجد اختبار"
                                    });
                            }

                            // قراءة بيانات البطاقات
                            if (reader.NextResult())
                            {
                                if (reader.Read())
                                {
                                    calculatedComprehensive.TotalStudentNumbers =
                                        reader["TotalStudentNumbers"] != DBNull.Value
                                            ? Convert.ToInt32(reader["TotalStudentNumbers"])
                                            : 0;

                                    calculatedComprehensive.AttendanceAvrage =
                                        reader["AttendanceAvrage"] != DBNull.Value
                                            ? Convert.ToDecimal(reader["AttendanceAvrage"])
                                            : 0.00m;

                                    calculatedComprehensive.EvaluationCount =
                                        reader["EvaluationCount"] != DBNull.Value
                                            ? Convert.ToInt32(reader["EvaluationCount"])
                                            : 0;

                                    calculatedComprehensive.EvaluationAvrage =
                                        reader["EvaluationAvrage"] != DBNull.Value
                                            ? reader["EvaluationAvrage"].ToString()
                                            : "لا توجد اختبارات";
                                }
                            }
                        }

                        object obj = cmd.Parameters["@TotalPage"].Value;

                        if (obj != null && obj != DBNull.Value)
                            short.TryParse(obj.ToString(), out TotalPage);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return (lst, calculatedComprehensive);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="CircleID">-1 => all Circles</param>
        /// <param name="PageNO">number of page</param>
        /// <param name="RecordsInPage">record in every page</param>
        static public (List<clsEntityComprehensiveReports.clsStudentComprehensiveDetail> ComprehensiveDetail, clsEntityComprehensiveReports.clsCalculatedStudentComprehensive CalculatedComprehensive)
        GetStudentComprehensive(
            int StudentID,
            byte Month,
            short Year,
            short PageNO,
            byte RecordsInPage,
            ref short TotalPage,
            bool ReturnMainData)
        {
            var lst = new List<clsEntityComprehensiveReports.clsStudentComprehensiveDetail>();
            var calculated = new clsEntityComprehensiveReports.clsCalculatedStudentComprehensive();
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_StudentComprehensive", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentID", StudentID);
                        cmd.Parameters.AddWithValue("@Month", Month);
                        cmd.Parameters.AddWithValue("@Year", Year);
                        cmd.Parameters.AddWithValue("@PageNO", PageNO);
                        cmd.Parameters.AddWithValue("@RecordsInPage", RecordsInPage);
                        cmd.Parameters.AddWithValue("@ReturnMainData", ReturnMainData);
                        
                        cmd.Parameters.Add("@TotalPage", SqlDbType.SmallInt)
                           .Direction = ParameterDirection.Output;

                        conn.Open();


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lst.Add(new clsEntityComprehensiveReports.clsStudentComprehensiveDetail()
                                {
                                    UpdateDate = reader["UpdateDate"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["UpdateDate"])
                                        : DateTime.MinValue,
                                    TeacherName = reader["TeacherName"] != DBNull.Value
                                        ? Convert.ToString(reader["TeacherName"])
                                        : string.Empty,
                                    AyaText = reader["AyaText"] != DBNull.Value
                                        ? Convert.ToString(reader["AyaText"])
                                        : string.Empty,
                                    SurraName = reader["SurraName"] != DBNull.Value
                                        ? Convert.ToString(reader["SurraName"])
                                        : string.Empty,

                                });
                            }

                            if (reader.NextResult())
                            {
                                if (reader.Read())
                                {
                                    calculated.AttendancePercentage =
                                        reader["AttendancePercentage"] != DBNull.Value
                                            ? Convert.ToDecimal(reader["AttendancePercentage"])
                                            : 0;

                                    calculated.EvaluationCount =
                                        reader["EvaluationCount"] != DBNull.Value
                                            ? Convert.ToInt32(reader["EvaluationCount"])
                                            : 0;

                                    calculated.AyahProgrees =
                                        reader["AyahProgrees"] != DBNull.Value
                                            ? Convert.ToInt16(reader["EvaluationCount"])
                                            : (short)0;

                                    calculated.EvaluationAvrage =
                                        reader["EvaluationAvrage"] != DBNull.Value
                                            ? reader["EvaluationAvrage"].ToString()
                                            : string.Empty;
                                }
                            }
                        }
                        object obj = cmd.Parameters["@TotalPage"].Value;
                        if (obj != null && short.TryParse(obj.ToString(), out TotalPage)) { }


                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return (lst, calculated);
        }



    }
}
