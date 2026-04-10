using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityPerson
    {
        public int PersonID { get; set; } = -1;
        public DateTime BirthDate { get; set; } = DateTime.MinValue;
        public string FirstName { get; set; } = string.Empty;
        public string SecodName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get { return $"{FirstName} {SecodName}{(string.IsNullOrEmpty(ThirdName)?"": $" {ThirdName}" )} {LastName}"; } }
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
