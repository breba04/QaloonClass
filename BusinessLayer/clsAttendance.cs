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
    public class clsAttendance
    {
        enum enMode { Add, Update }
        enMode _Mode;
        clsEntityAttendance EntityAttendance;
        public int AttendanceID { get { return EntityAttendance.AttendanceID; }  } 
        public int StudentID { get { return EntityAttendance.StudentID; } }
        public DateTime AttendanceDate { get { return EntityAttendance.AttendanceDate; } }
        public byte Status { get { return EntityAttendance.Status; } }
        public clsAttendance()
        {
            EntityAttendance = new clsEntityAttendance();
            _Mode = enMode.Add;
        }

        private clsAttendance(clsEntityAttendance EntityAttendance)
        {
            this.EntityAttendance = EntityAttendance;
            _Mode = enMode.Update;
        }

        private bool AddAttendance()
        {
            EntityAttendance.AttendanceID = clsAttendanceDataAccess.AddAttendance(EntityAttendance);
            return EntityAttendance.AttendanceID != default(int);
        }

        public bool UpdateAttendance(clsEntityAttendance EntityAttendance)
        {
            return clsAttendanceDataAccess.UpdateAttendance(EntityAttendance);
        }

        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddAttendance();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateAttendance(EntityAttendance);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }

        public bool DeleteAttendance()
        {
            return clsAttendanceDataAccess.DeleteAttendance(EntityAttendance.AttendanceID);
        }

        public DataTable SelectAllAttendances()
        {
            return clsAttendanceDataAccess.SelectAllAttendances();
        }
    }
}