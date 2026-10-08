using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;

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
                using (SqlCommand cmd = new SqlCommand("SP_Report_GetCircleAttendance", conn))
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
                using (SqlCommand cmd = new SqlCommand("SP_Report_GetAttendanceStudent", conn))
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
        static public (List<clsEntityAttandanceReports.clsStudentAttendanceDetail> AttendanceDetail, clsEntityAttandanceReports.clsCalculatedAttendance CalculatedAttendance)
            GetCircleEvaluation(
            int StudentID, DateTime DateFrom ,DateTime DateTo,short PageNO,byte RecordsInPage, ref short TotalPage, bool ReturnMainData)
        {
            List<clsEntityAttandanceReports.clsStudentAttendanceDetail> lst = new List<clsEntityAttandanceReports.clsStudentAttendanceDetail>();
            clsEntityAttandanceReports.clsCalculatedAttendance calculatedAttendance = new clsEntityAttandanceReports.clsCalculatedAttendance();
            using (SqlConnection conn = new SqlConnection(clsConnectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Report_GetEvaluationCircle", conn))
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
    }
}
