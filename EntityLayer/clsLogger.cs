using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace EntityLayer
{
    public class clsLogger
    {
        public enum enLogType
        {
            Information = 1,
            Warning = 2,
            Error = 3
        }
        public enum enLogLevel
        {
            DataLayer = 1,
            Business = 2,
            UI = 3
        }

        bool AddLogToDB(string LogMessage,int UserID,enLogType type,enLogLevel level,string OparationName,DateTime LogDate ,string Notes )
        {
            try
            {
                return true;
            }
            catch (Exception Ex)
            {
                return AddLogToFile(Ex,LogMessage, UserID, type, level, OparationName, LogDate, Notes);
            }
        }
        bool AddLogToFile(Exception Ex,string LogMessage,int UserID,enLogType type,enLogLevel level,string OparationName,DateTime LogDate ,string Notes)
        {
            try
            {

                System.IO.File.AppendAllText("Logs.txt",
                   $"//{Ex}" + DateTime.Now.ToString() + " | " + LogMessage + Environment.NewLine);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
