using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsReports
    {
        static public DayOfWeek[] WeekEndDayes = { DayOfWeek.Tuesday, DayOfWeek.Friday };
        public enum enReportType { AllStudent = 1, OneStudent };

        //يجب تعديل هذا المتغير وجلبه من الاعدادات او من قاعدة البيانات
        private sbyte NumberOfAllowedAbsentDays = 2;

        public List<clsEntityAttandanceReports.clsCircleAttendanceDetail> CircleAttendanceDetail { get; private set; }
        public List<clsEntityAttandanceReports.clsStudentAttendanceDetail> StudentAttendanceDetail { get; private set; }
        private clsEntityAttandanceReports.clsCalculatedAttendance CalculatedAttendance { get; set; }
        short _TotalPage;
        public clsReports()
        {
            CircleAttendanceDetail = new List<clsEntityAttandanceReports.clsCircleAttendanceDetail>();
            StudentAttendanceDetail = new List<clsEntityAttandanceReports.clsStudentAttendanceDetail>();
            CalculatedAttendance = new clsEntityAttandanceReports.clsCalculatedAttendance();
            _TotalPage = 0;
        }
        static int _GetWorkingDaysMath(DateTime startDate, DateTime endDate)
        {
            DateTime FirstAttendanceRegistration = clsAttendance.GetFirstAttendanceRegistrationDate();

            startDate = FirstAttendanceRegistration.Date != DateTime.MinValue && FirstAttendanceRegistration.Date != DateTime.MaxValue
                && FirstAttendanceRegistration.Date > startDate.Date ? FirstAttendanceRegistration : startDate;

            int totalDays = (int)(endDate.Date - startDate.Date).TotalDays + 1;
            if (totalDays <= 0) return 0;

            int weeks = totalDays / 7;
            int remainingDays = totalDays % 7;

            int workingDays = weeks * 5;

            for (int i = 0; i < remainingDays; i++)
            {
                DayOfWeek day = startDate.AddDays(weeks * 7 + i).DayOfWeek;
                if (!WeekEndDayes.Contains(day))
                {
                    workingDays++;
                }
            }

            return workingDays;
        }
        public int TotalStudentNumbers { get => CalculatedAttendance.TotalStudentNumbers; private set => CalculatedAttendance.TotalStudentNumbers = value; }
        public int TotalPresentDays { get => CalculatedAttendance.TotalPresentDays; private set => CalculatedAttendance.TotalPresentDays = value; }
        public int TotalAbsentDays { get => CalculatedAttendance.TotalAbsentDays; private set => CalculatedAttendance.TotalAbsentDays = value; }
        public int TotalExcusedAbsentDays { get => CalculatedAttendance.TotalExcusedAbsentDays; private set => CalculatedAttendance.TotalExcusedAbsentDays = value; }
        public int TotalRegistrationDays { get => TotalPresentDays + TotalAbsentDays + TotalExcusedAbsentDays; }
        public double AttendancePercentage { get => CalculatedAttendance.AttendancePercentage; private set => CalculatedAttendance.AttendancePercentage = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CircleID"> -1=> All Circles</param>
        /// <returns> Count of Total Pages</returns>
        public short GenarateAttandanceReport(int ID, DateTime DateFrom, DateTime DateTo, short PageNO, byte RecordsInPage , enReportType type)
        {
            short totalPages = 0;
            bool HasData;
            if (type == enReportType.AllStudent)
            {
                var AttandanceReport = clsReportsDataAccess.GetCircleAttandanceReport(ID, DateFrom, DateTo, PageNO, RecordsInPage, ref totalPages, true);
                this.CalculatedAttendance = AttandanceReport.CalculatedAttendance;
                this.CircleAttendanceDetail = AttandanceReport.AttendanceDetail;
                HasData = CircleAttendanceDetail != null &&
                          CircleAttendanceDetail.Count > 0;
            }
            else
            {
                var AttandanceReport = clsReportsDataAccess.GetStudentAttandanceReport(ID, DateFrom, DateTo, PageNO, RecordsInPage, ref totalPages, true);
                this.CalculatedAttendance = AttandanceReport.CalculatedAttendance;
                this.StudentAttendanceDetail = AttandanceReport.AttendanceDetail;

                HasData = StudentAttendanceDetail != null &&
                          StudentAttendanceDetail.Count > 0;
            }


            if (CalculatedAttendance == null || !HasData)
            {
                CalculatedAttendance = CalculatedAttendance == null ? new clsEntityAttandanceReports.clsCalculatedAttendance():CalculatedAttendance;
                CircleAttendanceDetail = new List<clsEntityAttandanceReports.clsCircleAttendanceDetail>();
                StudentAttendanceDetail = new List<clsEntityAttandanceReports.clsStudentAttendanceDetail>();
                _TotalPage = 0;
                return _TotalPage;
            }

            _TotalPage = totalPages > 0 ? totalPages : _TotalPage;
            //int WorkingDays = _GetWorkingDaysMath(DateFrom, DateTo);

            //CalculatedAttendance.AttendancePercentage = WorkingDays > 0
            //    ? ((double)AttandanceReport.CalculatedAttendance.TotalPresentDays / (WorkingDays * TotalStudentNumbers)) * 100 : 0.0;

            int TotalRecords = TotalAbsentDays + TotalExcusedAbsentDays + TotalPresentDays;

            AttendancePercentage = TotalRecords > 0 ? ((double)TotalPresentDays / TotalRecords) * 100 : 0.0;

            if (type == enReportType.AllStudent)
            {
                SetStatusForEveryRow();
            }
            return _TotalPage;
        }
        private void SetStatusForEveryRow()
        {
            foreach (var item in CircleAttendanceDetail)
            {
                if (item.TotalAbsent <= NumberOfAllowedAbsentDays)
                {
                    item.Status = "منتظم";
                }
                else
                {
                    item.Status = "يحتاج متابعة";
                }
            }
        }
    }
}
