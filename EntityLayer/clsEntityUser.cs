using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityUser
    {
        public int UserID { get; set; } = -1;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public clsEntityPerson PersonInfo { get; set; } = new clsEntityPerson();
        public int UserRole { get; set; } = -1;
    }
}
