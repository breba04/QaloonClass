using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEntitySettings
    {
        public int SettingID { get; set; } = -1;
        public string SettingKey { get; set; } = string.Empty;
        public string SettingValue { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
