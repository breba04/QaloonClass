
using System;

namespace EntityLayer
{
    public class clsEntityComprehensiveReports
    {
        public class clsCircleComprehensiveDetail
        {
            clsEntityReports _EntityReports = new clsEntityReports();

            public string FullName
            {
                get => _EntityReports.FullName;
                set => _EntityReports.FullName = value;
            }

            public string SeatsNumber { get; set; } = string.Empty;

            public string CircleName
            {
                get => _EntityReports.CircleName;
                set => _EntityReports.CircleName = value;
            }

            public string TeacherName
            {
                get => _EntityReports.TeacherName;
                set => _EntityReports.TeacherName = value;
            }

            public string CurrentProgress { get; set; } = "غير معرف";

            public decimal AttendancePercentage { get; set; } = 0.00m;

            public string LastEvaluation { get; set; } = "لا يوجد اختبار";
        }

        public class clsCalculatedCircleComprehensive
        {
            public int TotalStudentNumbers { get; set; } = 0;

            public decimal AttendanceAvrage { get; set; } = 0.00m;

            public int EvaluationCount { get; set; } = 0;

            public string EvaluationAvrage { get; set; } = "لا توجد اختبارات";
        }

        public class clsStudentComprehensiveDetail
        {
            public string CurrentProgress { get; set; } = "غير معرف";

            public decimal AttendancePercentage { get; set; } = 0.00m;

            public string LastEvaluation { get; set; } = "لا يوجد اختبار";
        }

        public class clsCalculatedStudentComprehensive
        {
            public int EvaluationCount { get; set; } = 0;

            public string LastEvaluation { get; set; } = "لا يوجد اختبار";

            public string EvaluationAvrage { get; set; } = "لا توجد اختبارات";

            public decimal AttendancePercentage { get; set; } = 0.00m;
        }
    }
}