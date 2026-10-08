using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityAttandanceReports
    {
        public class clsCircleAttendanceDetail
        {
            public string FullName { get; set; } = string.Empty;
            public string CircleName { get; set; } = string.Empty;
            public string TeacherName { get; set; } = string.Empty;
            public short TotalPresent { get; set; } = 0;
            public short TotalAbsent { get; set; } = 0;
            public short TotalExcusedAbsent { get; set; } = 0;
            public string Status { get; set; } = string.Empty;

        }
        public class clsStudentAttendanceDetail
        {
            public string StatusName { get; set; } = string.Empty;
            public string AttendanceDate { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;

        }
        public class clsCalculatedAttendance
        {
            public int TotalStudentNumbers { get; set; } = 0;
            public int TotalAbsentDays { get; set; } = 0;
            public int TotalExcusedAbsentDays { get; set; } = 0;
            public int TotalPresentDays { get; set; } = 0;
            public double AttendancePercentage { get; set; } = 0.0;
        }
    }
}
