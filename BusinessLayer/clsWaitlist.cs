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
    public class clsWaitlist
    {
        enum enMode { Add, Update }
        enMode _Mode;
        clsEntityWaitlist EntityWaitlist = new clsEntityWaitlist();

        public clsWaitlist()
        {
            EntityWaitlist.WaitlistID = -1;
            EntityWaitlist.FullName = "";
            EntityWaitlist.Age = 0;
            EntityWaitlist.ParentPhone = "";
            EntityWaitlist.Address = "";
            EntityWaitlist.RegistrationDate = DateTime.Now;
            EntityWaitlist.Notes = "";
            EntityWaitlist.IsAdded = false;
            _Mode = enMode.Add;
        }

        private clsWaitlist(clsEntityWaitlist EntityWaitlist)
        {
            this.EntityWaitlist = EntityWaitlist;
            _Mode = enMode.Update;
        }

        private bool AddWaitlist()
        {
            EntityWaitlist.WaitlistID = clsWaitlistDataAccess.AddWaitlist(EntityWaitlist);
            return EntityWaitlist.WaitlistID != default(int);
        }

        public bool UpdateWaitlist(clsEntityWaitlist EntityWaitlist)
        {
            return clsWaitlistDataAccess.UpdateWaitlist(EntityWaitlist);
        }

        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddWaitlist();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateWaitlist(EntityWaitlist);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }

        public bool DeleteWaitlist()
        {
            return clsWaitlistDataAccess.DeleteWaitlist(EntityWaitlist.WaitlistID);
        }

        public DataTable SelectAllWaitlist()
        {
            return clsWaitlistDataAccess.SelectAllWaitlist();
        }
    }
}