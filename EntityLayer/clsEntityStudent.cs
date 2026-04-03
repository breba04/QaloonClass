using System;

namespace EntityLayer
{
    public class clsEntityStudent
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ParentPhone { get; set; }
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
        public int CircleID { get; set; }
        public clsEntityCircle CircleInfo { get; set; }
    }
}