
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using EntityLayer;
using static EntityLayer.clsEntityCircle;

namespace BusinessLayer
{
    public class clsCircles
    {
        static public event Action<int> OnCircleAddedOrUpdated;
        public enum enMode { Add, Update }

        private enMode _Mode;

        private clsEntityCircle EntityCircle;
        public int CircleID
        {
            get => EntityCircle.CircleID;
            set => EntityCircle.CircleID = value;
        }
        public string CircleName
        {
            get => EntityCircle.CircleName;
            set => EntityCircle.CircleName = value;
        }
        public int TeacherID
        {
            get => EntityCircle.TeacherID;
            set => EntityCircle.TeacherID = value;
        }
        public byte MaxCapacity
        {
            get => EntityCircle.MaxCapacity;
            set => EntityCircle.MaxCapacity = value;
        }
        public byte CurrentStudentNumbers
        {
            get => EntityCircle.CurrentStudentNumbers;
            set => EntityCircle.CurrentStudentNumbers = value;
        }
        public enScheduleType ScheduleType
        {
            get => EntityCircle.ScheduleType;
            set => EntityCircle.ScheduleType = value;
        }
        public DateTime? StartTime
        {
            get => EntityCircle.StartTime;
            set => EntityCircle.StartTime = value;
        }
        public byte? PrayerID
        {
            get => EntityCircle.PrayerID;
            set => EntityCircle.PrayerID = value;
        }

        public bool CannAdded
        {
            get => EntityCircle.CannAdded;
        }
        public static List<KeyValuePair<byte, string>> GetAllPrayers()
        {
            return new List<KeyValuePair<byte, string>>
            {
                new KeyValuePair<byte, string>(
                    (byte)clsEntityCircle.enPrayer.Fajr, "الفجر"),

                new KeyValuePair<byte, string>(
                    (byte)clsEntityCircle.enPrayer.Dhuhr, "الظهر"),

                new KeyValuePair<byte, string>(
                    (byte)clsEntityCircle.enPrayer.Asr, "العصر"),

                new KeyValuePair<byte, string>(
                    (byte)clsEntityCircle.enPrayer.Maghrib, "المغرب"),

                new KeyValuePair<byte, string>(
                    (byte)clsEntityCircle.enPrayer.Isha, "العشاء")
            };
        }
        public clsCircles()
        {
            EntityCircle = new clsEntityCircle();
            _Mode = enMode.Add;
        }

        private clsCircles(clsEntityCircle EntityCircle)
        {
            this.EntityCircle = EntityCircle;
            _Mode = enMode.Update;
        }
        private bool AddCircle()
        {
            EntityCircle.CircleID =
                clsCirclesDataAccess.AddCircle(EntityCircle);

            if (EntityCircle.CircleID > 0)
            {
                var Log = new clsEntityActivityLog()
                {
                    ActionType = "إضافة حلقة",
                    EntityType = "حلقة",
                    EntityID = EntityCircle.CircleID,
                    UserID = clsCurrentUser.CurrentUser?.UserID ?? -1
                };

                clsEventManager.OnActivityAdded(this, Log);

                _Mode = enMode.Update;

                return true;
            }

            return false;
        }
        private bool UpdateCircle()
        {
            if (clsCirclesDataAccess.UpdateCircle(EntityCircle))
            {
                var Log = new clsEntityActivityLog()
                {
                    ActionType = "تعديل حلقة",
                    EntityType = "حلقة",
                    EntityID = EntityCircle.CircleID,
                    UserID = clsCurrentUser.CurrentUser?.UserID ?? -1
                };

                clsEventManager.OnActivityAdded(this, Log);

                return true;
            }

            return false;
        }
        public bool Save()
        {
            bool IsSuccess = false;

            try
            {
                switch (_Mode)
                {
                    case enMode.Add:
                        IsSuccess = AddCircle();
                        break;

                    case enMode.Update:
                        IsSuccess = UpdateCircle();
                        break;

                    default:
                        throw new InvalidOperationException(
                            "وضع غير صالح.");
                }
                if(IsSuccess)
                {
                    OnCircleAddedOrUpdated?.Invoke(CircleID);
                }
                return IsSuccess;
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(Save),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء حفظ بيانات الحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(Save),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        public bool DeleteCircle()
        {
            try
            {
                return clsCirclesDataAccess.DeleteCircle(
                    EntityCircle.CircleID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(DeleteCircle),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء محاولة حذف الحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(DeleteCircle),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public DataTable SelectAllCircles()
        {
            try
            {
                if (clsCurrentUser.CurrentUser == null)
                    throw new InvalidOperationException(
                        "لا يوجد مستخدم مسجل الدخول.");

                if (clsCurrentUser.CurrentUser.IsAdmin)
                    return clsCirclesDataAccess.SelectAllCircles();

                return clsCirclesDataAccess.GetllEpisodesTeacher(
                    clsCurrentUser.CurrentUser.UserID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllCircles),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع بيانات الحلقات.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllCircles),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public DataTable SelectAllCirclesMiniData()
        {
            try
            {
                return clsCirclesDataAccess.SelectAllCirclesMiniData();
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllCirclesMiniData),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع بيانات الحلقات.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllCirclesMiniData),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public DataTable GetllEpisodesTeacher()
        {
            try
            {
                return clsCirclesDataAccess.GetllEpisodesTeacher(
                    clsCurrentUser.CurrentUser.UserID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetllEpisodesTeacher),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع حلقات المعلم.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetllEpisodesTeacher),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public DataTable GetAllCircleView(
            byte PageNo, byte RecordInPage)
        {
            try
            {
                return clsCirclesDataAccess.GetAllCircleView(
                    PageNo, RecordInPage);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAllCircleView),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع عرض الحلقات.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetAllCircleView),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public short GetNewCirclesStatsLastMonth()
        {
            try
            {
                return clsCirclesDataAccess.GetNewCirclesStatsLastMonth();
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetNewCirclesStatsLastMonth),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع إحصائيات الحلقات.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetNewCirclesStatsLastMonth),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public byte GetTotalPagesRecordsInCircleView(
            byte RecordInPage)
        {
            try
            {
                return clsCirclesDataAccess.GetTotalPagesRecordsInCircleView(
                    RecordInPage);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetTotalPagesRecordsInCircleView),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء حساب عدد صفحات الحلقات.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetTotalPagesRecordsInCircleView),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public byte GetRemainingSeatsInClass(int CircleID)
        {
            try
            {
                return clsCirclesDataAccess.GetRemainingSeatsInClass(
                    CircleID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetRemainingSeatsInClass),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع المقاعد المتبقية في الحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetRemainingSeatsInClass),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public int GetSupervisorByCircleID(int CircleID)
        {
            try
            {
                return clsCirclesDataAccess.GetSupervisorByCircleID(
                    CircleID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetSupervisorByCircleID),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع بيانات مشرف الحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetSupervisorByCircleID),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public bool IsCircleExist(int CircleID)
        {
            try
            {
                return clsCirclesDataAccess.IsCircleExist(CircleID);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(IsCircleExist),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء التحقق من وجود الحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(IsCircleExist),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public clsCircles FindCircleByID(int CircleID)
        {
            try
            {
                clsEntityCircle circle = new clsEntityCircle()
                {
                    CircleID = CircleID
                };

                if (clsCirclesDataAccess.FindCircleByID(circle))
                    return new clsCircles(circle);

                return null;
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(FindCircleByID),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع بيانات الحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(FindCircleByID),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
        static public clsEntityCircle FindEntityCircleByID(int CircleID)
        {
            clsCircles circle = FindCircleByID(CircleID);

            if (circle == null)
                return null;

            return new clsEntityCircle()
            {
                CircleID = CircleID,
                CircleName = circle.CircleName,
                MaxCapacity = circle.MaxCapacity,
                TeacherID = circle.TeacherID,
                CurrentStudentNumbers = circle.CurrentStudentNumbers
            };
        }
        static public bool AddingSeatsInCircle(
            int circleID, byte CountSeats)
        {
            try
            {
                return clsCirclesDataAccess.AddingSeatsInCircle(
                    circleID, CountSeats);
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(AddingSeatsInCircle),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء إضافة مقاعد للحلقة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(AddingSeatsInCircle),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }

        static public byte GetNumberOfAvailableSeats()
        {
            try
            {
                return clsCirclesDataAccess.GetNumberOfAvailableSeats();
            }
            catch (SqlException ex)
            {
                string ErrorMessage =
                    clsUtilBusiness.GetExceptionMassege(ex);

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetNumberOfAvailableSeats),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage =
                    "حدث خطأ أثناء استرجاع عدد المقاعد المتاحة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetNumberOfAvailableSeats),
                    DateTime.Now);

                throw new InvalidOperationException(
                    ErrorMessage, ex);
            }
        }
    }
}
