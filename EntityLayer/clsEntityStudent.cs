using System;

namespace EntityLayer
{
    public class clsEntityStudent
    {
        public int StudentID { get; set; } = -1;
        public string ParentPhone { get; set; } = string.Empty;
        public string SeatsNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public clsEntityPerson PersonInfo { get; set; } = new clsEntityPerson();
        public int CircleID { get; set; } = -1;
        public clsEntityCircle CircleInfo { get; set; } = new clsEntityCircle();
    }
}