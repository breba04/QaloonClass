using System;

namespace EntityLayer
{
    public class clsEntityStudentProgress
    {
        public int ProgressID { get; set; }
        public int StudentID { get; set; }
        public short AyahID { get; set; }
        public DateTime UpdateDate { get; set; }
        public int TeacherID { get; set; }
    }
}