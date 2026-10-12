using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityEvaluationReports
    {
        public class clsCircleEvaluationDetail
        {
            clsEntityReports _EntityReports = new clsEntityReports();
            public string FullName { get => _EntityReports.FullName; set => _EntityReports.FullName = value; }
            public string CircleName { get => _EntityReports.CircleName; set => _EntityReports.CircleName = value; }
            public string TeacherName { get => _EntityReports.TeacherName; set => _EntityReports.TeacherName = value; }
            public string EvaluationName { get; set; } = string.Empty;
            public string EvaluationDate { get; set; } = string.Empty;
            public string EvaluationRate { get; set; } = string.Empty;
            public string EvaluationFromAya { get; set; } = string.Empty;
            public string EvaluationToAya { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;
        }

        public class clsCalculatedEvaluation
        {
            public int TotalStudentNumbers { get; set; } = 0;
            public int TotalEvaluationNumbers { get; set; } = 0;
            public string BestStudent { get; set; } = string.Empty;
            public string EvaluationAvrage { get; set; } = string.Empty;
        }
        public class clsCalculatedStudentEvaluation
        {
            public int TotalEvaluationNumbers { get; set; } = 0;
            public string LastEvaluation { get; set; } = string.Empty;
            public string BestRate { get; set; } = string.Empty;
            public string EvaluationAvrage { get; set; } = string.Empty;
        }
    }
}