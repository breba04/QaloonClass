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
        static public DataTable GetAlljazza()
        {
            return clsMoshafQaloonDataAccess.GetAlljazza();
        }
        static public DataTable GetAllAyatFromSurrah(byte SurrahNo,byte NumberOfLetters)
        {
            return clsMoshafQaloonDataAccess.GetAllAyatFromSurrah(SurrahNo, NumberOfLetters);
        }
    }
}
