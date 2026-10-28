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
    public class clsStudents
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;
        public clsEntityStudent EntityStudent;
        public int StudentID { get  => EntityStudent.StudentID; set  => EntityStudent.StudentID = value;  } 
        public string ParentPhone { get => EntityStudent.ParentPhone; set => EntityStudent.ParentPhone = value; }
        public string SeatsNumber { get => EntityStudent.SeatsNumber; set => EntityStudent.SeatsNumber = value; }
        public DateTime JoinDate { get => EntityStudent.JoinDate; set => EntityStudent.JoinDate = value; } 
        public clsEntityPerson PersonInfo { get => EntityStudent.PersonInfo; set => EntityStudent.PersonInfo = value; }
        public DateTime BirthDate { get => EntityStudent.PersonInfo.BirthDate; set => EntityStudent.PersonInfo.BirthDate = value; } 
        public string FirstName { get => EntityStudent.PersonInfo.FirstName; set => EntityStudent.PersonInfo.FirstName = value; } 
        public string SecodName { get => EntityStudent.PersonInfo.SecodName; set => EntityStudent.PersonInfo.SecodName = value; } 
        public string ThirdName { get => EntityStudent.PersonInfo.ThirdName; set => EntityStudent.PersonInfo.ThirdName = value; } 
        public string LastName { get => EntityStudent.PersonInfo.LastName; set => EntityStudent.PersonInfo.LastName = value; } 
        public string FullName { get => EntityStudent.PersonInfo.FullName; } 
        public string Address { get => EntityStudent.PersonInfo.Address; set => EntityStudent.PersonInfo.Address = value; } 
        public bool IsActive { get =>EntityStudent.PersonInfo.IsActive; set => EntityStudent.PersonInfo.IsActive = value; } 

        public int CircleID { get => EntityStudent.CircleID; set => EntityStudent.CircleID = value; } 
        public clsEntityCircle CircleInfo { get => EntityStudent.CircleInfo; } 
        public string ImagePath { get => EntityStudent.PersonInfo.ImagePath; set => EntityStudent.PersonInfo.ImagePath = value; } 
        public clsStudents()
        {
            this.EntityStudent = new clsEntityStudent();
            _Mode = enMode.Add;
        }
        private clsStudents(clsEntityStudent EntityStudent)
        {
            this.EntityStudent = EntityStudent;
            _Mode = enMode.Update;
        }
        private bool AddStudent()
        {
            EntityStudent.StudentID = clsStudentsDataAccess.AddStudent(EntityStudent);
            if(EntityStudent.StudentID != -1)
            {
                //var Log = new clsEntityActivityLog()
                //{ ActionType = "إضافة طالب", EntityType = "طالب", EntityID = EntityStudent.StudentID
                //, UserID = clsCurrentUser.CurrentUser.UserID };

                //clsEventManager.OnActivityAdded(this, Log);
                _Mode = enMode.Update;
                return true;
            }
            return false;
        }
        private bool UpdateStudent()
        {
            if(clsStudentsDataAccess.UpdateStudent(EntityStudent))
            {
                var Log = new clsEntityActivityLog()
                {
                    ActionType = "تعديل طالب",
                    EntityType = "طالب",
                    EntityID = EntityStudent.StudentID
                ,
                    UserID = clsCurrentUser.CurrentUser.UserID
                };

                clsEventManager.OnActivityAdded(this, Log);
                return true;
            }
            return false;
        }
        private void _ValidateBusinessRules()
        {
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(SecodName) ||
                string.IsNullOrWhiteSpace(LastName))
            {
                throw new InvalidOperationException(
                    "يرجى إدخال الاسم الأول والثاني واسم العائلة.");
            }

            if (CircleID <= 0 || !clsCircles.IsCircleExist(CircleID))
            {
                throw new InvalidOperationException(
                    "الحلقة المحددة غير موجودة.");
            }

            if (_Mode == enMode.Update && !IsStudentExist(StudentID))
            {
                throw new InvalidOperationException(
                    "الطالب المراد تعديله غير موجود.");
            }
        }
        public bool Save()
        {
            _ValidateBusinessRules();
            try
            {
                switch (_Mode)
                {
                    case enMode.Add:
                        return AddStudent();

                    case enMode.Update:
                        return UpdateStudent();
                    default:
                        throw new InvalidOperationException("وضع غير صالح.");
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
                    string.Join(".", nameof(clsUsers), nameof(Save)),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء حفظ الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    string.Join(".", nameof(clsUsers), nameof(Save)),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
        static public clsStudents Find(int studentId)
        {
            try
            {

                clsEntityStudent EntityStudent = new clsEntityStudent();
                EntityStudent.StudentID = studentId;

                if (clsStudentsDataAccess.FindStudentByID(EntityStudent))
                {
                    clsEntityCircle entityCircle = new clsEntityCircle() { CircleID = EntityStudent.CircleID };
                    EntityStudent.CircleInfo = clsCircles.FindEntityCircleByID(entityCircle.CircleID);
                    return new clsStudents(EntityStudent);
                }

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
                    string.Join(".",nameof(clsUsers),nameof(Find)),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع بيانات الطالب.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    string.Join(".", nameof(clsUsers), nameof(Find)),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
        public bool DeleteStudent()
        {
            return clsStudentsDataAccess.DeleteStudent(EntityStudent.StudentID) >0;
        }
        static public int DeleteStudent(int studentID)
        {
            return clsStudentsDataAccess.DeleteStudent(studentID);
        }
        static public bool IsStudentExist(int studentId)
        {
            return clsStudentsDataAccess.IsStudentExist(studentId);
        }
        static public DataTable SelectAllStudents()
        {
            if(
                true||
                clsCurrentUser.CurrentUser.IsAdmin
                )
                return clsStudentsDataAccess.SelectAllStudents();
            else
            {
                return clsStudentsDataAccess.SelectAllStudentsByTeacherID(clsCurrentUser.CurrentUser.UserID);
            }
        }
        static public DataTable SelectAllStudents(int CircleID)
        {
            if(clsCurrentUser.CurrentUser.UserRole == (int) clsEntityUser.enUserRole.Admin 
                ||clsCircles.GetSupervisorByCircleID(CircleID) == clsCurrentUser.CurrentUser.UserID)
                return clsStudentsDataAccess.SelectAllStudents(CircleID);

            return new DataTable();
        }
        static public DataTable SelectAllStudentsMiniData(int CircleID)
        {
            if(clsCurrentUser.CurrentUser.UserRole == (int) clsEntityUser.enUserRole.Admin 
                ||clsCircles.GetSupervisorByCircleID(CircleID) == clsCurrentUser.CurrentUser.UserID)
                return clsStudentsDataAccess.SelectAllStudentsMiniData(CircleID);

            return new DataTable();
        }
        static public short GetNewStudentsStatusLastMonth()
        {
            return clsStudentsDataAccess.GetNewStudentsStatusLastMonth();
        }
        static public short GetTotalStudentAbsent(DateTime FromDate,DateTime ToDate)
        {
            return clsStudentsDataAccess.GetTotalStudentAbsent(FromDate, ToDate);
        }
        static public short GetTotalStudentAbsentLastMonth()
        {
            DateTime Now = DateTime.Now;
            return GetTotalStudentAbsent(new DateTime(Now.Year, Now.Month, 1), new DateTime(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year,Now.Month)));
        }
        static public bool ChangeStudentStatus(int StudentID, bool IsActive)
        {
            return clsStudentsDataAccess.ChangeStudentStatus(StudentID, IsActive);
        }
        static public int GetTotalActiceStudents()
        {
            return clsStudentsDataAccess.GetTotalActiceStudents();
        }
    }
}