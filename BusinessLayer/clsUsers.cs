

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
        clsEntityUser EntityUser = new clsEntityUser();
        public clsUsers()
        {
            EntityUser.UserID = -1;
            EntityUser.UserName = "";
            EntityUser.Password = "";
            EntityUser.FullName = "";
            EntityUser.UserRole = -1;
            _Mode = enMode.Add;
        }
        private clsUsers(clsEntityUser EntityUser)
        {
            this.EntityUser = EntityUser;
            _Mode = enMode.Update;
        }
        private bool AddUsers()
        {
            EntityUser.UserID = clsUsersDataAccess.AddUsers(EntityUser);
            return EntityUser.UserID != default(int);
        }
        public bool UpdateUsers(clsEntityUser EntityUser)
        {
            return clsUsersDataAccess.UpdateUsers(EntityUser);
        }
        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddUsers();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateUsers(EntityUser);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }
        public bool DeleteUsers()
        {
            return clsUsersDataAccess.DeleteUsers(EntityUser.UserID);
        }
        public DataTable SelectAllUserss()
        {
            return clsUsersDataAccess.SelectAllUserss();
        }
        static public bool IsUsersExist(int UserID)
        {
            return clsUsersDataAccess.IsUsersExist(UserID);
        }
    }

}

