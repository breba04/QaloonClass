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
        public clsEntityAttendance EntityAttendance = new clsEntityAttendance();

        public clsAttendance()
        {
            EntityAttendance.AttendanceID = -1;
            EntityAttendance.StudentID = -1;
            EntityAttendance.AttendanceDate = DateTime.Now;
            EntityAttendance.Status = 0; // tinyint
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