using System;

namespace EntityLayer
{
    public class clsEntityStudent
    {
        public int StudentID { get; set; } = -1;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.MinValue;
        public string ParentPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; } = DateTime.MinValue;
        public bool IsActive { get; set; } = false;
        public int CircleID { get; set; } = -1;
        public clsEntityCircle CircleInfo { get; set; } = new clsEntityCircle();
    }
}