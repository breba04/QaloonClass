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
        clsEntityWaitlist EntityWaitlist;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public int WaitlistID { get { return EntityWaitlist.WaitlistID; } }
        public string FirstName { get { return EntityWaitlist.FirstName; } } 
        public string SecondName { get { return EntityWaitlist.SecondName; } } 
        public string ThirdName { get { return EntityWaitlist.ThirdName; } } 
        public string LastName { get { return EntityWaitlist.LastName; } } 
        public string ParentPhone { get { return EntityWaitlist.ParentPhone; } } 
        public string Address { get { return EntityWaitlist.Address; } }
        public DateTime RegistrationDate { get { return EntityWaitlist.RegistrationDate; } }
        public string Notes { get { return EntityWaitlist.Notes; } }
        public bool IsAdded { get { return EntityWaitlist.IsAdded; } }
        public clsWaitlist()
        {
            EntityWaitlist = new clsEntityWaitlist();
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