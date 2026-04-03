using System;

namespace EntityLayer
{
    public class clsEntityAttendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public byte Status { get; set; }
    }
}