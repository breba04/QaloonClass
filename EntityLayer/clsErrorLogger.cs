using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
namespace EntityLayer
{

    public static class clsErrorLogger
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

        private static readonly string _LogFilePath = GetLogFilePath();

        private static string GetLogFilePath()
        {
            string ProgramPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Logs.txt");

            try
            {
                using (FileStream fs = new FileStream(
                    ProgramPath, FileMode.Append, FileAccess.Write))
                {
                    // نجح الوصول للملف
                }

                return ProgramPath;
            }
            catch (UnauthorizedAccessException)
            {
                string DocumentsPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

                string LogFolder = Path.Combine(DocumentsPath, "Tahfiz");

                Directory.CreateDirectory(LogFolder);

                return Path.Combine(LogFolder, "Logs.txt");
            }
            catch (IOException)
            {
                string DocumentsPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

                string LogFolder = Path.Combine(DocumentsPath, "Tahfiz");

                Directory.CreateDirectory(LogFolder);

                return Path.Combine(LogFolder, "Logs.txt");
            }
        }
        // حافظنا على التوقيع القديم لتجنب تعديل الاستدعاءات الحالية.
        public static bool AddLogToDB(
            string LogMessage,
            int UserID,
            enLogType type,
            enLogLevel level,
            string OparationName,
            DateTime LogDate,
            string Notes = null)
        {
            return AddLogToFile(
                null,
                LogMessage,
                UserID,
                type,
                level,
                OparationName,
                LogDate,
                Notes);
        }

        // للاستدعاء عند وجود Exception فعلي.
        public static bool AddExceptionLog(
            Exception Ex,
            string LogMessage,
            int UserID,
            enLogType type,
            enLogLevel level,
            string OparationName,
            DateTime LogDate = default,
            string Notes = null)
        {
            if (LogDate == default)
            {
                LogDate = DateTime.Now;
            }
            return AddLogToFile(
                Ex,
                LogMessage,
                UserID,
                type,
                level,
                OparationName,
                LogDate,
                Notes);
        }

        public static bool AddLogToFile(
            Exception Ex,
            string LogMessage,
            int UserID,
            enLogType type,
            enLogLevel level,
            string OparationName,
            DateTime LogDate,
            string Notes = null)
        {
            try
            {
                string DirectoryPath = Path.GetDirectoryName(_LogFilePath);

                Directory.CreateDirectory(DirectoryPath);

                StringBuilder LogEntry = new StringBuilder();

                LogEntry.AppendLine("----------------------------------------");
                LogEntry.AppendLine($"Date: {LogDate:yyyy-MM-dd HH:mm:ss.fff}");
                LogEntry.AppendLine($"UserID: {UserID}");
                LogEntry.AppendLine($"Type: {type}");
                LogEntry.AppendLine($"Level: {level}");
                LogEntry.AppendLine($"Operation: {OparationName}");
                LogEntry.AppendLine($"Message: {LogMessage}");
                LogEntry.AppendLine($"Notes: {Notes ?? string.Empty}");

                if (Ex != null)
                {
                    LogEntry.AppendLine("Exception:");
                    LogEntry.AppendLine(Ex.ToString());
                }

                LogEntry.AppendLine();

                File.AppendAllText(
                    _LogFilePath,
                    LogEntry.ToString(),
                    Encoding.UTF8);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
