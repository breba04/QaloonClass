using System;

namespace EntityLayer
{
    public class clsEntityCircle
    {
        public enum enScheduleType  {
            Prayer = 1,//بعد صلاة معينة
            FixedTime = 2
        }
        public int CircleID { get; set; } = -1;
        public string CircleName { get; set; } = string.Empty;
        public int TeacherID { get; set; } = -1;
        public byte MaxCapacity { get; set; } = 0;
        public byte CurrentStudentNumbers { get; set; } = 0;
        public enScheduleType ScheduleType { get; set; } = enScheduleType.Prayer;
        public DateTime? StartTime { get; set; } = null;
        public byte? PrayerID { get; set; } = null;
        public bool CannAdded { get => MaxCapacity > CurrentStudentNumbers; }

    }
}