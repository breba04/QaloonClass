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
        public  List<clsEntityAttandanceReports.clsAttendanceDetail> AttendanceDetail { get; private set; }
        private clsEntityAttandanceReports.clsCalculatedAttendance CalculatedAttendance { get;  set; }
        short _TotalPage;
        public clsReports()
        {
            AttendanceDetail = new List<clsEntityAttandanceReports.clsAttendanceDetail>();
            CalculatedAttendance = new clsEntityAttandanceReports.clsCalculatedAttendance();
            _TotalPage = 0;
        }
        static int _GetWorkingDaysMath(DateTime startDate, DateTime endDate)
        {
            DateTime FirstAttendanceRegistration = clsAttendance.GetFirstAttendanceRegistrationDate();

            startDate = FirstAttendanceRegistration.Date != DateTime.MinValue && FirstAttendanceRegistration.Date != DateTime.MaxValue 
                && FirstAttendanceRegistration.Date > startDate.Date? FirstAttendanceRegistration:startDate;

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
        public double AttendancePercentage { get => CalculatedAttendance.AttendancePercentage; private set => CalculatedAttendance.AttendancePercentage = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CircleID"> -1=> All Circles</param>
        /// <returns> Count of Total Pages</returns>
        public short GenarateAttandanceReport(int CircleID, DateTime DateFrom, DateTime DateTo, short PageNO, byte RecordsInPage)
        {
            short totalPages = 0;
            var AttandanceReport = clsReportsDataAccess.GetAttandanceReport(CircleID, DateFrom, DateTo, PageNO, RecordsInPage, ref totalPages, true);
            this.CalculatedAttendance = AttandanceReport.CalculatedAttendance;
            this.AttendanceDetail = AttandanceReport.AttendanceDetail;

            if (CalculatedAttendance == null || AttendanceDetail == null|| AttendanceDetail.Count == 0)
            {
                CalculatedAttendance = new clsEntityAttandanceReports.clsCalculatedAttendance();
                AttendanceDetail = new List<clsEntityAttandanceReports.clsAttendanceDetail>();
                _TotalPage = 0;
                return _TotalPage;
            }
            _TotalPage = totalPages > 0? totalPages : _TotalPage;
            int WorkingDays = _GetWorkingDaysMath(DateFrom, DateTo);

            CalculatedAttendance.AttendancePercentage = WorkingDays > 0
                ? ((double)AttandanceReport.CalculatedAttendance.TotalPresentDays /( WorkingDays * TotalStudentNumbers) )* 100 : 0.0;
            return _TotalPage;
        }
    }
}
