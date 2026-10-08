using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityEvaluationReports
    {
        public class clsEvaluationDetail
        {
            public string FullName { get; set; } = string.Empty;
            public string CircleName { get; set; } = string.Empty;
            public string TeacherName { get; set; } = string.Empty;

            public string EvaluationName { get; set; } = string.Empty;
            public string EvaluationDate { get; set; } = string.Empty;
            public double EvaluationRate { get; set; } = 0.0;

            public string EvaluationFromAya { get; set; } = string.Empty;
            public string EvaluationToAya { get; set; } = string.Empty;

            public string Notes { get; set; } = string.Empty;
        }
    }
}