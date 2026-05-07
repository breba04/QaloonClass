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
        public int AttendanceID { get => EntityAttendance.AttendanceID; }  
        public int StudentID { get => EntityAttendance.StudentID; set => EntityAttendance.StudentID = value; } 
        public DateTime AttendanceDate { get => EntityAttendance.AttendanceDate; set => EntityAttendance.AttendanceDate = value; } 
        public byte Status { get => EntityAttendance.Status; set => EntityAttendance.Status = value; } 
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