using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityclsLoginDetails
    {
        public int LoginID { get; set; } = -1;
        public int UserID { get; set; } = -1;
        public bool IsRemember {  get; set; } = false;
        public DateTime LoginDate { get; set; } = DateTime.MinValue;
        public string Notes = string.Empty;
    }
}
