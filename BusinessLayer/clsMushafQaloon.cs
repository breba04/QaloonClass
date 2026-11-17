
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
            try
            {
                return clsMoshafQaloonDataAccess.GetAllSurrah();
            }
            catch (SqlException ex)
            {
                string ErrorMessage = clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAllSurrah),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب قائمة السور.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAllSurrah),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public DataTable GetAlljazza()
        {
            try
            {
                return clsMoshafQaloonDataAccess.GetAlljazza();
            }
            catch (SqlException ex)
            {
                string ErrorMessage = clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAlljazza),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب قائمة الأجزاء.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAlljazza),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public DataTable GetAllAyatFromSurrah(byte SurrahNo, byte NumberOfLetters)
        {
            try
            {
                return clsMoshafQaloonDataAccess.GetAllAyatFromSurrah(SurrahNo, NumberOfLetters);
            }
            catch (SqlException ex)
            {
                string ErrorMessage = clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAllAyatFromSurrah),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب آيات السورة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAllAyatFromSurrah),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public string GetSurrahNameByAyaID(short AyaID)
        {
            try
            {
                return clsMoshafQaloonDataAccess.GetSurrahNameByAyaID(AyaID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage = clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetSurrahNameByAyaID),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب اسم السورة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetSurrahNameByAyaID),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public string GetSurrahNameByFirstAyaID(short AyaID)
        {
            try
            {
                return clsMoshafQaloonDataAccess.GetSurrahNameByFirstAyaID(AyaID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage = clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetSurrahNameByFirstAyaID),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب اسم السورة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetSurrahNameByFirstAyaID),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public string GetAyaText(short AyaID, byte NumberOfLetters)
        {
            try
            {
                return clsMoshafQaloonDataAccess.GetAyaText(AyaID, NumberOfLetters);
            }
            catch (SqlException ex)
            {
                string ErrorMessage = clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAyaText),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب نص الآية.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAyaText),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
    }
}
