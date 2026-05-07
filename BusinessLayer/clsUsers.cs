

/***************Users****************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
namespace BusinessLayer
{
    public class clsUsers
    {
        enum enMode { Add, Update }
        enMode _Mode;
        public clsEntityUser UserData ;
        public int UserID { get { return UserData.UserID; } }
        public string UserName { get { return UserData.UserName; } }
        public string Password { get { return UserData.Password; } }
        public clsEntityPerson PersonInfo { get { return UserData.PersonInfo; } }

        public int PersonID { get { return UserData.PersonInfo.PersonID; } }
        public DateTime BirthDate { get { return UserData.PersonInfo.BirthDate; } }
        public string FirstName { get { return UserData.PersonInfo.FirstName; } }
        public string SecodName { get { return UserData.PersonInfo.SecodName; } }
        public string ThirdName { get { return UserData.PersonInfo.ThirdName; } }
        public string LastName { get { return UserData.PersonInfo.LastName; } }
        public string FullName { get { return UserData.PersonInfo.FullName; } }
        public string Address { get { return UserData.PersonInfo.Address; } }
        public bool IsActive { get { return UserData.PersonInfo.IsActive; } }
        public int UserRole { get { return UserData.UserRole; } }
        public clsUsers()
        {
            this.UserData = new clsEntityUser();
            _Mode = enMode.Add;
        }
        private clsUsers(clsEntityUser EntityUser)
        {
            this.UserData = EntityUser;
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
            if (_Mode == enMode.Add)
            {
                return AddUsers();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateUsers();
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }
        public bool DeleteUsers()
        {
            return clsUsersDataAccess.DeleteUsers(UserData.UserID);
        }
        public DataTable SelectAllUserss()
        {
            return clsUsersDataAccess.SelectAllUserss();
        }
        static public bool IsUsersExist(int UserID)
        {
            return clsUsersDataAccess.IsUsersExist(UserID);
        }
        static public bool Login(string userName,string password,bool isRemember)
        {
            clsCurrentUser.CurrentUser  = new clsEntityUser() {UserName = userName ,Password = password};
            if (clsUsersDataAccess.Login(clsCurrentUser.CurrentUser))
            {
                clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails()
                {
                    UserID = clsCurrentUser.CurrentUser.UserID,
                    LoginDate = DateTime.Now,
                    IsRemember = isRemember,
                };
                clsLoginDetails.AddLoginDetails(loginDetails);

                //if (isRemember)
                //    clsGlobal.StoreUserNameAndPassWordInRegistry(clsCurrentUser.CurrentUser.UserName, clsCurrentUser.CurrentUser.Password);

                return true;
            }
            else
            {
                clsCurrentUser.CurrentUser = null;
                return false;
            }
        }
        static public void LoadLastLogin()
        {
            clsEntityclsLoginDetails loginDetails = new clsEntityclsLoginDetails();
            if (clsLoginDetailsDataAccess.FindLoginDetailsByID(loginDetails))
            {
                if (loginDetails.IsRemember)
                {
                    clsUsers user =  clsUsers.Find(loginDetails.UserID);
                    if(user != null)
                    {
                        clsCurrentUser.CurrentUser = new clsEntityUser()
                        {
                            UserID = user.UserID,
                            PersonInfo = user.PersonInfo,
                            UserName = user.UserName,
                            Password = user.Password,
                            UserRole = user.UserRole
                        }; 
                    }
                }
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

