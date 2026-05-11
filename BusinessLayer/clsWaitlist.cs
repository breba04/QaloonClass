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
        public DateTime BirthDate { get => EntityWaitlist.BirthDate; set => EntityWaitlist.BirthDate = value; } 
        public int WaitlistID { get => EntityWaitlist.WaitlistID; set => EntityWaitlist.WaitlistID = value; }
        public string FirstName { get => EntityWaitlist.FirstName; set => EntityWaitlist.FirstName = value; } 
        public string SecondName { get => EntityWaitlist.SecondName; set => EntityWaitlist.SecondName = value; } 
        public string ThirdName { get => EntityWaitlist.ThirdName; set => EntityWaitlist.ThirdName = value; } 
        public string LastName { get => EntityWaitlist.LastName; set => EntityWaitlist.LastName = value; } 
        public string ParentPhone { get => EntityWaitlist.ParentPhone; set => EntityWaitlist.ParentPhone = value; } 
        public string Address { get => EntityWaitlist.Address; set => EntityWaitlist.Address = value; }
        public DateTime RegistrationDate { get => EntityWaitlist.RegistrationDate; set => EntityWaitlist.RegistrationDate = value; }
        public string Notes { get => EntityWaitlist.Notes; set => EntityWaitlist.Notes = value; }
        public bool IsAdded { get => EntityWaitlist.IsAdded; set => EntityWaitlist.IsAdded = value; }
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

        public bool UpdateWaitlist()
        {
            return clsWaitlistDataAccess.UpdateWaitlist(EntityWaitlist);
        }

        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                if(AddWaitlist())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                    return false;
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateWaitlist();
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
        static public bool DeleteWaitlist(int WaitlistID)
        {
            if(clsCurrentUser.CurrentUser.IsAdmin)
                return clsWaitlistDataAccess.DeleteWaitlist(WaitlistID);
            return false; 
        }

        static public DataTable SelectAllWaitlist()
        {
            return clsWaitlistDataAccess.SelectAllWaitlist();
        }
        static public int TransferFromWaitlistToStudent(int waitlistId, int CircleID, string ImagePath)
        {
            clsEntityCircle CircleInfo = clsCurrentUser.CurrentUser.HasCircle ? clsCurrentUser.CurrentUser.CircleInfo
                : clsCircles.FindEntityCircleByID(CircleID);

            bool CanTransfer = false;
            if (CircleInfo != null && CircleInfo.CircleID != -1)
            {
                CanTransfer = clsCurrentUser.CurrentUser.IsAdmin || CircleInfo.CannAdded;
            }

            if (CanTransfer)
                return clsWaitlistDataAccess.TransferFromWaitlistToStudent(waitlistId, CircleID, ImagePath);

            return -1;
        }
    }
}