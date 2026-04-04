using System;

namespace EntityLayer
{
    public class clsEntityAttendance
    {
        public int AttendanceID { get; set; } = -1;
        public int StudentID { get; set; } = -1;
        public DateTime AttendanceDate { get; set; } = DateTime.MinValue;
        public byte Status { get; set; } = 0;
    }
}