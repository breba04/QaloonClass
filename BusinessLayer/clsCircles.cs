using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class clsCircles
    {
        enum enMode { Add, Update }
        enMode _Mode;
        clsEntityCircle EntityCircle;
        public int CircleID { get => EntityCircle.CircleID; set => EntityCircle.CircleID = value; }  
        public string CircleName { get => EntityCircle.CircleName; set => EntityCircle.CircleName = value; } 
        public int TeacherID { get => EntityCircle.TeacherID; set => EntityCircle.TeacherID = value; } 
        public sbyte MaxCapacity { get => EntityCircle.MaxCapacity; set => EntityCircle.MaxCapacity = value; } 
        public clsCircles()
        {
            EntityCircle = new clsEntityCircle();
            _Mode = enMode.Add;
        }

        private clsCircles(clsEntityCircle EntityCircle)
        {
            this.EntityCircle = EntityCircle;
            _Mode = enMode.Update;
        }
        private bool AddCircle()
        {
            EntityCircle.CircleID = clsCirclesDataAccess.AddCircle(EntityCircle);
            return EntityCircle.CircleID != default(int);
        }
        public bool UpdateCircle(clsEntityCircle EntityCircle)
        {
            return clsCirclesDataAccess.UpdateCircle(EntityCircle);
        }
        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddCircle();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateCircle(EntityCircle);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }
        public bool DeleteCircle()
        {
            return clsCirclesDataAccess.DeleteCircle(EntityCircle.CircleID);
        }
        static public DataTable SelectAllCircles()
        {
            return clsCirclesDataAccess.SelectAllCircles();
        }
        static public DataTable GetAllCircleView(byte PageNo, byte RecordInPage)
        {
            return clsCirclesDataAccess.GetAllCircleView(PageNo, RecordInPage);
        }
        static public short GetNewCirclesStatsLastMonth()
        {
            return clsCirclesDataAccess.GetNewCirclesStatsLastMonth();
        }
        static public byte GetTotalPagesRecordsInCircleView(byte RecordInPage)
        {
            return clsCirclesDataAccess.GetTotalPagesRecordsInCircleView(RecordInPage);
        }
        static public byte GetRemainingSeatsInClass(int CircleID)
        {
            return clsCirclesDataAccess.GetRemainingSeatsInClass(CircleID);
        }
        static public int GetSupervisorByCircleID(int CircleID)
        {
            return clsCirclesDataAccess.GetSupervisorByCircleID(CircleID);
        }
    }
}