
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
using static EntityLayer.clsEntityEvaluation;

namespace BusinessLayer
{
    public class clsEvaluations
    {
        enum enMode { Add, Update }

        //public enum enGrade { NotRecordedYet=0, Poor =1, Good , VeryGood, Excellent }

        enMode _Mode;
        clsEntityEvaluation EntityEvaluation;

        public int EvaluationID { get => EntityEvaluation.EvaluationID; }
        public int StudentID { get => EntityEvaluation.StudentID; set => EntityEvaluation.StudentID = value; }
        public short FromAyahID { get => EntityEvaluation.FromAyahID; set => EntityEvaluation.FromAyahID = value; }
        public short ToAyahID { get => EntityEvaluation.ToAyahID; set => EntityEvaluation.ToAyahID = value; }
        public enEvaluationType EvalType { get => EntityEvaluation.EvalType; set => EntityEvaluation.EvalType = value; }
        public DateTime EvalDate { get => EntityEvaluation.EvalDate; set => EntityEvaluation.EvalDate = value; }
        public bool IsEvaluationTaken { get => EntityEvaluation.IsEvaluationTaken; set => EntityEvaluation.IsEvaluationTaken = value; }
        public enRate? Rate { get => EntityEvaluation.Rate; set => EntityEvaluation.Rate = value; }
        public string Notes { get => EntityEvaluation.Notes; set => EntityEvaluation.Notes = value; }

        public clsEvaluations()
        {
            EntityEvaluation = new clsEntityEvaluation();
            _Mode = enMode.Add;
        }

        private clsEvaluations(clsEntityEvaluation EntityEvaluation)
        {
            this.EntityEvaluation = EntityEvaluation;
            _Mode = enMode.Update;
        }

        static public enRate? GetRateFromText(string text)
        {
            try
            {
                var ListRate = new List<string>() { "ممتاز", "جيد جدا", "جيد", "ضعيف" };

                if (!ListRate.Contains(text))
                    return null;

                return clsEvaluationsDataAccess.GetRateFromText(text);
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
                    nameof(GetRateFromText),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع التقييم من النص.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetRateFromText),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public string GetRateText(enRate Rate)
        {
            try
            {
                switch (Rate)
                {
                    case clsEntityEvaluation.enRate.Weak:
                        return "ضعيف";

                    case clsEntityEvaluation.enRate.Good:
                        return "جيد";

                    case clsEntityEvaluation.enRate.VeryGood:
                        return "جيد جدا";

                    default:
                        return "ممتاز";
                }
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
                    nameof(GetRateText),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء تحويل التقييم إلى نص.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetRateText),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        private bool AddEvaluation()
        {
            try
            {
                EntityEvaluation.EvaluationID = clsEvaluationsDataAccess.AddEvaluation(EntityEvaluation);

                if (EntityEvaluation.EvaluationID != -1)
                {
                    clsEventManager.OnEvaluationAdded(this, EntityEvaluation);
                    return true;
                }

                return false;
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
                    nameof(AddEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء إضافة التقييم.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(AddEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        public bool UpdateEvaluation(clsEntityEvaluation EntityEvaluation)
        {
            try
            {
                return clsEvaluationsDataAccess.UpdateEvaluation(EntityEvaluation);
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
                    nameof(UpdateEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء تعديل التقييم.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(UpdateEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        public bool Save()
        {
            try
            {
                if (_Mode == enMode.Add)
                {
                    return AddEvaluation();
                }
                else if (_Mode == enMode.Update)
                {
                    return UpdateEvaluation(EntityEvaluation);
                }
                else
                {
                    throw new Exception("Invalid mode");
                }
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
                string ErrorMessage = "حدث خطأ أثناء حفظ التقييم.";

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

        public bool DeleteEvaluation()
        {
            try
            {
                return clsEvaluationsDataAccess.DeleteEvaluation(EntityEvaluation.EvaluationID);
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
                    nameof(DeleteEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء حذف التقييم.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(DeleteEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public DataTable SelectAllEvaluationsTaken(DateTime From, DateTime To)
        {
            try
            {
                return clsEvaluationsDataAccess.SelectAllEvaluationsTaken(From, To);
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
                    nameof(SelectAllEvaluationsTaken),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع التقييمات المنفذة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllEvaluationsTaken),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public DataTable SelectAllEvaluationsNotTaken()
        {
            try
            {
                return clsEvaluationsDataAccess.SelectAllEvaluationsNotTaken();
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
                    nameof(SelectAllEvaluationsNotTaken),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع التقييمات غير المنفذة.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllEvaluationsNotTaken),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public DataTable SelectAllTestType()
        {
            try
            {
                return clsEvaluationsDataAccess.SelectAllTestType();
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
                    nameof(SelectAllTestType),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع أنواع الاختبارات.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(SelectAllTestType),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public clsEvaluations FindEvaluation(int evaluationID)
        {
            try
            {
                clsEntityEvaluation evaluation = new clsEntityEvaluation() { EvaluationID = evaluationID };

                if (clsEvaluationsDataAccess.FindEvaluation(evaluation))
                    return new clsEvaluations(evaluation);

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
                    nameof(FindEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع بيانات التقييم.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(FindEvaluation),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }

        static public int GetNumberOfStudentsNotTakeEvaluationInMonth()
        {
            try
            {
                return clsEvaluationsDataAccess.GetNumberOfStudentsNotTakeEvaluationInMonth();
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
                    nameof(GetNumberOfStudentsNotTakeEvaluationInMonth),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء حساب عدد الطلاب الذين لم يخضعوا للتقييم خلال الشهر.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(GetNumberOfStudentsNotTakeEvaluationInMonth),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
    }
}
