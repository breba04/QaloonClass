using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityUser
    {
        public enum enUserRole { Admin = 1, Teacher = 2 }
        public int UserID { get; set; } = -1;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public clsEntityPerson PersonInfo { get; set; } = new clsEntityPerson();
        public int PersonID { get => PersonInfo.PersonID; } 
        public DateTime BirthDate { get => PersonInfo.BirthDate; set => PersonInfo.BirthDate = value; } 
        public string FirstName { get=> PersonInfo.FirstName; set => PersonInfo.FirstName = value; } 
        public string SecodName { get=> PersonInfo.SecodName; set => PersonInfo.SecodName = value; } 
        public string ThirdName { get=> PersonInfo.ThirdName; set => PersonInfo.ThirdName = value; } 
        public string LastName { get => PersonInfo.LastName; set => PersonInfo.LastName = value; } 
        public string FullName { get => PersonInfo.FullName;  } 
        public string Address { get  => PersonInfo.Address; set => PersonInfo.Address = value; } 
        public bool IsActive { get   => PersonInfo.IsActive; set => PersonInfo.IsActive = value; } 
        public int UserRole { get; set; } = -1;
    }
}
