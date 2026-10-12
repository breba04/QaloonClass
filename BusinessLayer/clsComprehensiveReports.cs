
using EntityLayer;
using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public class clsComprehensiveReports
    {
        public List<clsEntityComprehensiveReports.clsCircleComprehensiveDetail>
            CircleComprehensiveDetail
        { get; private set; }

        public clsEntityComprehensiveReports.clsCalculatedCircleComprehensive
            CalculatedCircleComprehensive
        { get; private set; }

        public List<clsEntityComprehensiveReports.clsStudentComprehensiveDetail>
            StudentComprehensiveDetail
        { get; private set; }

        public clsEntityComprehensiveReports.clsCalculatedStudentComprehensive
            CalculatedStudentComprehensive
        { get; private set; }

        short _TotalPage;

        public clsComprehensiveReports()
        {
            CircleComprehensiveDetail =
                new List<clsEntityComprehensiveReports.clsCircleComprehensiveDetail>();

            CalculatedCircleComprehensive =
                new clsEntityComprehensiveReports.clsCalculatedCircleComprehensive();

            StudentComprehensiveDetail =
                new List<clsEntityComprehensiveReports.clsStudentComprehensiveDetail>();

            CalculatedStudentComprehensive =
                new clsEntityComprehensiveReports.clsCalculatedStudentComprehensive();

            _TotalPage = 0;
        }

        /// <summary>
        /// Generates the comprehensive report for a circle, all circles,
        /// or a specific student.
        /// </summary>
        /// <param name="CircleID">-1 => All Circles</param>
        /// <param name="Month">Selected month</param>
        /// <param name="Year">Selected year</param>
        /// <param name="PageNO">Page number</param>
        /// <param name="RecordsInPage">Number of records per page</param>
        /// <param name="Type">AllStudent or OneStudent</param>
        /// <returns>Total number of pages</returns>
        public short GenerateComprehensiveReport(
            int CircleID,
            byte Month,
            short Year,
            short PageNO,
            byte RecordsInPage,
            clsEntityReports.enReportType Type)
        {
            short TotalPage = 0;
            bool HasData = false;

            if (Type == clsEntityReports.enReportType.AllStudent)
            {
                var ComprehensiveReport =
                    clsReportsDataAccess.GetCircleComprehensive(
                        CircleID,
                        Month,
                        Year,
                        PageNO,
                        RecordsInPage,
                        ref TotalPage,
                        true);

                CircleComprehensiveDetail =
                    ComprehensiveReport.ComprehensiveDetail;

                CalculatedCircleComprehensive =
                    ComprehensiveReport.CalculatedComprehensive;

                HasData = CircleComprehensiveDetail != null
                    && CircleComprehensiveDetail.Count > 0;
            }
            else
            {
                //var ComprehensiveReport =
                //    clsReportsDataAccess.GetStudentComprehensive(
                //        CircleID,
                //        Month,
                //        Year,
                //        PageNO,
                //        RecordsInPage,
                //        ref TotalPage,
                //        true);

                //StudentComprehensiveDetail =
                //    ComprehensiveReport.ComprehensiveDetail;

                //CalculatedStudentComprehensive =
                //    ComprehensiveReport.CalculatedComprehensive;

               HasData = StudentComprehensiveDetail != null
                    && StudentComprehensiveDetail.Count > 0;
            }

            if (!HasData)
            {
                CircleComprehensiveDetail =
                    new List<clsEntityComprehensiveReports.clsCircleComprehensiveDetail>();

                StudentComprehensiveDetail =
                    new List<clsEntityComprehensiveReports.clsStudentComprehensiveDetail>();

                CalculatedCircleComprehensive =
                    new clsEntityComprehensiveReports.clsCalculatedCircleComprehensive();

                CalculatedStudentComprehensive =
                    new clsEntityComprehensiveReports.clsCalculatedStudentComprehensive();

                _TotalPage = 0;
                return _TotalPage;
            }

            _TotalPage = TotalPage;

            return _TotalPage;
        }
    }
}