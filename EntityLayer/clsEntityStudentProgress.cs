using System;

namespace EntityLayer
{
    public class clsEntityStudentProgress
    {
        public int ProgressID { get; set; } = -1;
        public int StudentID { get; set; } = -1;
        public short AyahID { get; set; } = -1;
        public DateTime UpdateDate { get; set; } = DateTime.MinValue;
        public int TeacherID { get; set; } = -1;
    }
}