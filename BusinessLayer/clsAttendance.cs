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
        private void AddAttendance(List<clsAttendance> ListAttendanceStudents)
        {
            ListAttendanceStudents.ForEach(e =>
            {
                if(!e.Save())
                {
                    if (e.StudentID == -1)
                        throw new ArgumentNullException("لم يتم تعيين معرف للطالب");

                    throw new InvalidOperationException($"حدث خطأ اثناء محاولة حفظ حالة الحضور للطالب صاحب ID : {e.StudentID}");
                }
            }
            );
            
        }

        public bool UpdateAttendance(clsEntityAttendance EntityAttendance)
        {
            return clsAttendanceDataAccess.UpdateAttendance(EntityAttendance);
        }
        static public clsAttendance Find(int studentId)
        {
            clsEntityAttendance Entity = new clsEntityAttendance();
            Entity.StudentID = studentId;

            if (clsAttendanceDataAccess.FindAttendanceByStudentID(Entity))
                return new clsAttendance(Entity);

            return null;
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
        static public DataTable SelectAllAttendancesToday(int CircleID)
        {
            if(clsCurrentUser.CurrentUser.IsAdmin 
                || clsCircles.GetSupervisorByCircleID(CircleID) == clsCurrentUser.CurrentUser.UserID)
            {
                return clsAttendanceDataAccess.SelectAllAttendances(CircleID,DateTime.Now);
            }
            return null;
        }
        static public DataTable SelectAllAttendancesStatus()
        {
            return clsAttendanceDataAccess.SelectAllAttendancesStatus();
        }
        static public DataTable SelectAllStudentsForAttendance(int CircleID)
        {
            return clsAttendanceDataAccess.SelectAllStudentsForAttendance(CircleID);
        }
        static public bool IsAttendanceExistsToday(int CircleID)
        {
            return clsAttendanceDataAccess.IsAttendanceExistsToday( CircleID);
        }
    }
}