using System;

namespace EntityLayer
{
    public class clsEntityWaitlist
    {
        public int WaitlistID { get; set; } = -1;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string ParentPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = string.Empty;
        public bool IsAdded { get; set; } = false;
    }
}