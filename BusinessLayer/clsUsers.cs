

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
        static public clsUsers Login(string userName,string password)
        {
            clsEntityUser EntityUser = new clsEntityUser() {UserName = userName ,Password = password};
            if (clsUsersDataAccess.Login(EntityUser))
            {
                return new clsUsers(EntityUser);
            }
            else
            {
                return null;
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

