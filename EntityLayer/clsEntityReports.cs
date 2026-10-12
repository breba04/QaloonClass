using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityReports
    {
        public enum enReportType { AllStudent = 1, OneStudent };
        public string FullName { get; set; } = string.Empty;
        public string CircleName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
    }
}
