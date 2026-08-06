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
        static public string GetSurrahNameByAyaID(short AyaID)
        {
            return clsMoshafQaloonDataAccess.GetSurrahNameByAyaID(AyaID);
        }
        static public string GetSurrahNameByFirstAyaID(short AyaID)
        {
            return clsMoshafQaloonDataAccess.GetSurrahNameByFirstAyaID(AyaID);
        }
        static public string GetAyaText(short AyaID, byte NumberOfLetters)
        {
            return clsMoshafQaloonDataAccess.GetAyaText(AyaID,NumberOfLetters);
        }
    }
}
