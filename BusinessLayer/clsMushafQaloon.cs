using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class clsMushafQaloon
    {
        static public DataTable GetAllSurrah()
        {
            return clsMoshafQaloonDataAccess.GetAllSurrah();
        }
        static public DataTable GetAllAyatFromSurrah(byte SurrahNo)
        {
            return clsMoshafQaloonDataAccess.GetAllAyatFromSurrah(SurrahNo);
        }
    }
}
