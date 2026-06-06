using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntityActivityLog
    {
        public int ActivityID { get; set; } = -1;

        public string ActionType { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;

        public int? EntityID { get; set; } = null;

        public string Description { get; set; } = string.Empty;

        public DateTime ActivityDate { get; set; } = DateTime.Now;
        public int UserID { get; set; } = -1;

    }
}
