using System;

namespace EntityLayer
{
    public class clsEntityWaitlist
    {
        public int WaitlistID { get; set; } = -1;
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; } = -1;
        public string ParentPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = string.Empty;
        public bool IsAdded { get; set; } = false;
    }
}