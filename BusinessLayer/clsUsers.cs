

/***************Users****************/
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class clsUsers
    {
        
        enum enMode { Add, Update }
        enMode _Mode;
        public clsEntityUser UserData ;
        public int UserID { get => UserData.UserID; } 
        public string UserName { get => UserData.UserName; set => UserData.UserName = value; }
        public string Password { get => UserData.Password; set => UserData.Password = value; }
        public clsEntityPerson PersonInfo { get => UserData.PersonInfo;}
        public int PersonID  { get => PersonInfo.PersonID; set => PersonInfo.PersonID = value; } 
        public DateTime BirthDate { get => PersonInfo.BirthDate; set => PersonInfo.BirthDate = value; }
        public string FirstName { get => PersonInfo.FirstName; set => PersonInfo.FirstName= value; }
        public string SecodName { get => PersonInfo.SecodName; set => PersonInfo.SecodName = value; }
        public string ThirdName { get => PersonInfo.ThirdName; set => PersonInfo.ThirdName = value; }
        public string LastName { get => PersonInfo.LastName; set => PersonInfo.LastName = value; }
        public string FullName { get => PersonInfo.FullName; }
        public string Address { get => PersonInfo.Address; set => PersonInfo.Address = value;     }
        public bool IsActive { get => PersonInfo.IsActive; set => PersonInfo.IsActive = value; }
        public int UserRole { get => UserData.UserRole; set => UserData.UserRole = value; }
        public int CircleID { get => UserData.CircleID; set => UserData.CircleID = value; }
        public string ImagePath { get => UserData.PersonInfo.ImagePath; set => UserData.PersonInfo.ImagePath = value; }

        public clsEntityCircle CircleInfo { get => UserData.CircleInfo; set => UserData.CircleInfo = value; }
        public bool HasCircle { get => UserData.HasCircle; }
        public string CircleName { get => UserData.CircleName; }
        public byte MaxCapacity { get => UserData.CircleMaxCapacity; }
        public byte CurrentStudentNumbersInCircle { get => UserData.CurrentStudentNumbersInCircle; }
        public bool CannAddedToCircle { get => UserData.CannAddedToCircle; }
        public clsUsers()
        {
            this.UserData = new clsEntityUser();
            _Mode = enMode.Add;
        }
        private clsUsers(clsEntityUser EntityUser)
        {
            this.UserData = EntityUser;
            this.CircleInfo = clsCircles.FindEntityCircleByID(CircleID);
            _Mode = enMode.Update;
        }
        private bool AddUsers()
        {
            UserData.UserID = clsUsersDataAccess.AddUsers(UserData);
            return UserData.UserID != default(int);
        }
        public bool UpdateUsers()
        {
            return clsUsersDataAccess.UpdateUsers(UserData);
        }
        public bool Save()
        {
            try
            {
                switch (_Mode)
                {
                    case enMode.Add:
                        return AddUsers();

                    case enMode.Update:
                        return UpdateUsers();
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
                    clsCurrentUser.CurrentUser.UserID,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(Save));

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء حفظ بيانات المستخدم.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(LoadLastLogin),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
        public bool DeleteUsers()
        {
            return clsUsersDataAccess.DeleteUsers(UserData.UserID);
        }
        static public DataTable SelectAllUsers()
        {
            return clsUsersDataAccess.SelectAllUserss();
        }
        static public DataTable SelectAllTeachers()
        {
            return clsUsersDataAccess.SelectAllTeachers();
        }
        static public bool IsUsersExist(int UserID)
        {
            try
            {
                return clsUsersDataAccess.IsUsersExist(UserID);
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
                    nameof(IsUsersExist),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع بيانات آخر تسجيل دخول.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(IsUsersExist),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
        static public bool Login(string userName,string password,bool isRemember)
        {
            try
            {
                clsCurrentUser.CurrentUser = new clsEntityUser() { UserName = userName, Password = password };
                if (clsUsersDataAccess.Login(clsCurrentUser.CurrentUser))
                {
                    clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails()
                    {
                        UserID = clsCurrentUser.CurrentUser.UserID,
                        LoginDate = DateTime.Now,
                        IsRemember = isRemember,
                    };
                    clsLoginDetails.AddLoginDetails(loginDetails);

                    if (isRemember)
                    {
                        clsUtilBusiness.StoreUserNameAndPassWordInRegistry(userName, password);
                    }

                    return true;
                }
                else
                {
                    clsCurrentUser.CurrentUser = null;
                    return false;
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
                    nameof(Login),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع بيانات آخر تسجيل دخول.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(Login),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
        static public void LoadLastLogin()
        {
            try
            {
                clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails();

                if (!clsLoginDetailsDataAccess.FindLoginDetailsByID(loginDetails))
                    return;

                if (!loginDetails.IsRemember)
                    return;

                clsUsers user = clsUsers.Find(loginDetails.UserID);

                if (user == null)
                    return;

                clsCurrentUser.CurrentUser = new clsEntityUser()
                {
                    UserID = user.UserID,
                    PersonInfo = user.PersonInfo,
                    UserName = user.UserName,
                    Password = user.Password,
                    UserRole = user.UserRole
                };
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
                    nameof(LoadLastLogin),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "حدث خطأ أثناء استرجاع بيانات آخر تسجيل دخول.";

                clsErrorLogger.AddExceptionLog(
                    ex,
                    ErrorMessage,
                    clsCurrentUser.CurrentUser?.UserID ?? -1,
                    clsErrorLogger.enLogType.Error,
                    clsErrorLogger.enLogLevel.Business,
                    nameof(LoadLastLogin),
                    DateTime.Now);

                throw new InvalidOperationException(ErrorMessage, ex);
            }
        }
        static public clsUsers Find(int UserID)
        {
            clsEntityUser EntityUser = new clsEntityUser() { UserID = UserID };
            if (clsUsersDataAccess.FindByUserID(EntityUser))
            {
                return new clsUsers(EntityUser);
            }
            else
            {
                return null;
            }
        }
    }

}

