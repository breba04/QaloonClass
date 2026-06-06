using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsConnectionString
    {
        static public string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }
}
