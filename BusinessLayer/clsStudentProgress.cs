
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class clsStudentProgress
    {
        enum enMode { Add, Update }
        enMode _Mode;
        public clsEntityStudentProgress EntityProgress;

        public int ProgressID { get => EntityProgress.ProgressID; set => EntityProgress.ProgressID = value; }
        public int StudentID { get => EntityProgress.StudentID; set => EntityProgress.StudentID = value; }
        public short AyahID { get => EntityProgress.AyahID; set => EntityProgress.AyahID = value; }
        public byte SurrahID { get => EntityProgress.SurrahID; set => EntityProgress.SurrahID = value; }
        public DateTime UpdateDate { get => EntityProgress.UpdateDate; set => EntityProgress.UpdateDate = value; }
        public int TeacherID { get => EntityProgress.TeacherID; set => EntityProgress.TeacherID = value; }

        public clsStudentProgress()
        {
            EntityProgress = new clsEntityStudentProgress();
            _Mode = enMode.Add;
        }

        private clsStudentProgress(clsEntityStudentProgress EntityProgress)
        {
            this.EntityProgress = EntityProgress;
            _Mode = enMode.Update;
        }

        public bool AddProgress()
        {
            try
            {
                EntityProgress.ProgressID = clsStudentProgressDataAccess.AddProgress(EntityProgress);
                return EntityProgress.ProgressID != default(int);
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
                    nameof(AddProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء إضافة تقدم الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(AddProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        public bool UpdateProgress()
        {
            try
            {
                return clsStudentProgressDataAccess.UpdateProgress(EntityProgress);
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
                    nameof(UpdateProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء تحديث تقدم الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(UpdateProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        public bool Save()
        {
            try
            {
                //clsStudentProgress LastProgress = clsStudentProgress.GetLastStudentProgress(StudentID);
                //if(LastProgress != null &&  AyahID < LastProgress.AyahID )
                //{
                //    throw new Exception("لا يمكن الرجوع للخلف");
                //}
                //bool result = _Mode == enMode.Add? AddProgress()
                //    : UpdateProgress();

                bool result = AddProgress();

                if (!result) return false;

                clsEventManager.OnActivityAdded(this, new clsEntityActivityLog
                {
                    ActionType = "تحديث تقدم للطالب",
                    EntityType = "تقدم الطالب",
                    EntityID = ProgressID,
                    ActivityDate = DateTime.Now,
                    UserID = clsCurrentUser.CurrentUser.UserID
                });

                return true;
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
                    nameof(Save),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء حفظ تقدم الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(Save),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        public bool DeleteProgress()
        {
            try
            {
                return clsStudentProgressDataAccess.DeleteProgress(EntityProgress.ProgressID);
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
                    nameof(DeleteProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء حذف تقدم الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(DeleteProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        public DataTable SelectAllProgress()
        {
            try
            {
                return clsStudentProgressDataAccess.SelectAllProgress();
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
                    nameof(SelectAllProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب تقدم الطلاب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public clsStudentProgress Find(int StudentID)
        {
            try
            {
                clsEntityStudentProgress studentProgress = new clsEntityStudentProgress() { StudentID = StudentID };

                if (clsStudentProgressDataAccess.FindProgressByStudentID(studentProgress))
                    return new clsStudentProgress(studentProgress);

                return null;
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
                    nameof(Find),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء البحث عن تقدم الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(Find),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public clsStudentProgress GetLastStudentProgress(int StudentID)
        {
            try
            {
                clsEntityStudentProgress studentProgress = new clsEntityStudentProgress() { StudentID = StudentID };

                if (clsStudentProgressDataAccess.GetLastStudentProgress(studentProgress))
                    return new clsStudentProgress(studentProgress);

                return null;
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
                    nameof(GetLastStudentProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء جلب آخر تقدم للطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetLastStudentProgress),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
    }
}
