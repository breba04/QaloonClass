using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsEvaluationReports
    {
        public List<clsEntityEvaluationReports.clsCircleEvaluationDetail> EvaluationDetail
        {
            get;
            private set;
        }
        public clsEntityEvaluationReports.clsCalculatedEvaluation CalculatedEvaluation
        {
            get;
            private set;
        }
        public clsEntityEvaluationReports.clsCalculatedStudentEvaluation StudentCalculatedEvaluation
        {
            get;
            private set;
        }
        short _TotalPage;
        public clsEvaluationReports()
        {
            EvaluationDetail =
                new List<clsEntityEvaluationReports.clsCircleEvaluationDetail>();

            CalculatedEvaluation =
                new clsEntityEvaluationReports.clsCalculatedEvaluation();

            _TotalPage = 0;
        }

        /// <summary>
        /// Generates the evaluation report for a specific circle or all circles.
        /// </summary>
        /// <param name="CircleID">-1 => All Circles</param>
        /// <param name="DateFrom">Start date</param>
        /// <param name="DateTo">End date</param>
        /// <param name="PageNO">Page number</param>
        /// <param name="RecordsInPage">Number of records per page</param>
        /// <param name="ReturnMainData">Whether to return the summary data</param>
        /// <param name="NumberOfLetters">Maximum number of letters for Quran text</param>
        /// <returns>Total number of pages</returns>
        public short GenerateEvaluationReport(
            int CircleID,
            DateTime DateFrom,
            DateTime DateTo,
            short PageNO,
            byte RecordsInPage,
            clsEntityReports.enReportType Type,
            byte NumberOfLetters)
        {
            short TotalPage = 0;
            bool HasData = false;
            if (Type == clsEntityReports.enReportType.AllStudent)
            {   

                var EvaluationReport =
                    clsReportsDataAccess.GetCircleEvaluation(
                        CircleID,
                        DateFrom,
                        DateTo,
                        PageNO,
                        RecordsInPage,
                        ref TotalPage,
                        true,
                        NumberOfLetters);

                EvaluationDetail = EvaluationReport.EvaluationDetail;
                CalculatedEvaluation = EvaluationReport.CalculatedEvaluation;
                HasData = EvaluationDetail != null;
            }
            else
            {
                var EvaluationReport =
                    clsReportsDataAccess.GetStudentEvaluation(
                        CircleID,
                        DateFrom,
                        DateTo,
                        PageNO,
                        RecordsInPage,
                        ref TotalPage,
                        true,
                        NumberOfLetters);

                EvaluationDetail = EvaluationReport.EvaluationDetail;
                StudentCalculatedEvaluation = EvaluationReport.CalculatedEvaluation;
                HasData = StudentCalculatedEvaluation != null ;
            }
            HasData = HasData && EvaluationDetail != null && EvaluationDetail.Count > 0;
            if (!HasData)
            {
                EvaluationDetail =
                    new List<clsEntityEvaluationReports.clsCircleEvaluationDetail>();
                CalculatedEvaluation =
                    new clsEntityEvaluationReports.clsCalculatedEvaluation();
                _TotalPage = 0;
                return _TotalPage;
            }

            _TotalPage = TotalPage;

            return _TotalPage;
        }
    }
}