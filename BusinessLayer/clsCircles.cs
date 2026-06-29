using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
using static EntityLayer.clsEntityCircle;

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
        public byte MaxCapacity { get => EntityCircle.MaxCapacity; set => EntityCircle.MaxCapacity = value; } 
        public byte CurrentStudentNumbers { get => EntityCircle.CurrentStudentNumbers; set => EntityCircle.MaxCapacity = value; }
        public enScheduleType ScheduleType { get => EntityCircle.ScheduleType; set => EntityCircle.ScheduleType = value; }
        public DateTime? StartTime { get => EntityCircle.StartTime; set => EntityCircle.StartTime = value; }
        public byte? PrayerID { get => EntityCircle.PrayerID; set => EntityCircle.PrayerID = value; }
        public bool CannAdded { get => EntityCircle.CannAdded; } 
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
            if(EntityCircle.CircleID != -1)
            {
                var Log = new clsEntityActivityLog()
                {
                    ActionType = "إضافة حلقة",
                    EntityType = "حلقة",
                    EntityID = EntityCircle.CircleID
                    ,
                    UserID = clsCurrentUser.CurrentUser.UserID
                };

                clsEventManager.OnActivityAdded(this, Log);
                return true;
            }
            return false;
        }
        public bool UpdateCircle()
        {
            if(clsCirclesDataAccess.UpdateCircle(EntityCircle))
            {
                var Log = new clsEntityActivityLog()
                {
                    ActionType = "تعديل حلقة",
                    EntityType = "حلقة",
                    EntityID = EntityCircle.CircleID,
                    UserID = clsCurrentUser.CurrentUser.UserID
                };

                clsEventManager.OnActivityAdded(this, Log);
                return true;
            }
            return false;
        }
        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddCircle();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateCircle();
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
            if 
                (
                true||
                    clsCurrentUser.CurrentUser.IsAdmin)
                return clsCirclesDataAccess.SelectAllCircles();
            else
                return clsCirclesDataAccess.GetllEpisodesTeacher(clsCurrentUser.CurrentUser.UserID);

        }
        static public DataTable GetllEpisodesTeacher()
        {
            return clsCirclesDataAccess.GetllEpisodesTeacher(clsCurrentUser.CurrentUser.UserID);
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
        static public clsCircles FindCircleByID(int CircleID)
        {
            clsEntityCircle circle = new clsEntityCircle(); 
            circle.CircleID = CircleID;

            if(clsCirclesDataAccess.FindCircleByID(circle))
                return new clsCircles(circle);

            return null;
        }
        static public clsEntityCircle FindEntityCircleByID(int CircleID)
        {
            clsCircles circle = FindCircleByID(CircleID);
            if (circle == null)
                return null;

            return new clsEntityCircle() 
            { 
                CircleID = CircleID ,
                CircleName = circle.CircleName ,
                MaxCapacity = circle.MaxCapacity , 
                TeacherID = circle.TeacherID,
                CurrentStudentNumbers = circle.CurrentStudentNumbers
            };
        }
        static public bool AddingSeatsInCircle(int circleID, byte CountSeats)
        {
            return clsCirclesDataAccess.AddingSeatsInCircle(circleID, CountSeats);
        }
        static public byte GetNumberOfAvailableSeats()
        {
            return clsCirclesDataAccess.GetNumberOfAvailableSeats();
        }

    }
}