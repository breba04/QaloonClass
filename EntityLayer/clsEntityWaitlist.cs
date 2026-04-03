using System;

namespace EntityLayer
{
    public class clsEntityWaitlist
    {
        public int WaitlistID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ParentPhone { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Notes { get; set; }
        public bool IsAdded { get; set; }
    }
}