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
    public class clsStudentProgress
    {
        enum enMode { Add, Update }
        enMode _Mode;
        public clsEntityStudentProgress EntityProgress ;
        public int ProgressID { get => EntityProgress.ProgressID; set => EntityProgress.ProgressID = value; } 
        public int StudentID { get => EntityProgress.StudentID; set => EntityProgress.StudentID = value; } 
        public short AyahID { get => EntityProgress.AyahID; set => EntityProgress.AyahID = value; } 
        public byte SurrahID { get => EntityProgress.SurrahID; set => EntityProgress.SurrahID = value; } 
        public DateTime UpdateDate { get => EntityProgress.UpdateDate; set => EntityProgress.UpdateDate = value; } 
        public int TeacherID { get => EntityProgress.TeacherID; set => EntityProgress.TeacherID = value; } 
        public clsStudentProgress()
        {
            EntityProgress = new clsEntityStudentProgress();
            _Mode = enMode.Add;
        }

        private clsStudentProgress(clsEntityStudentProgress EntityProgress)
        {
            this.EntityProgress = EntityProgress;
            _Mode = enMode.Update;
        }

        private bool AddProgress()
        {
            EntityProgress.ProgressID = clsStudentProgressDataAccess.AddProgress(EntityProgress);
            return EntityProgress.ProgressID != default(int);
        }

        public bool UpdateProgress()
        {
            return clsStudentProgressDataAccess.UpdateProgress(EntityProgress);
        }

        public bool Save()
        {

            clsStudentProgress LastProgress = clsStudentProgress.GetLastStudentProgress(StudentID);
            if(LastProgress != null &&  AyahID < LastProgress.AyahID )
            {
                throw new Exception("لا يمكن الرجوع للخلف");
            }
            bool result = _Mode == enMode.Add? AddProgress()
                : UpdateProgress();

            if(!result)return false;
            
            clsEventManager.OnActivityAdded(this,new clsEntityActivityLog
            {
                ActionType= "تحديث تقدم للطالب",
                EntityType= "تقدم الطالب",
                EntityID = ProgressID,
                ActivityDate = DateTime.Now,
                UserID = clsCurrentUser.CurrentUser.UserID
            });

            return true;
        }

        public bool DeleteProgress()
        {
            return clsStudentProgressDataAccess.DeleteProgress(EntityProgress.ProgressID);
        }
        public DataTable SelectAllProgress()
        {
            return clsStudentProgressDataAccess.SelectAllProgress();
        }
        static public clsStudentProgress Find(int StudentID)
        {
            clsEntityStudentProgress studentProgress = new clsEntityStudentProgress() { StudentID = StudentID };
            if(clsStudentProgressDataAccess.FindProgressByStudentID(studentProgress))
                return new clsStudentProgress(studentProgress);
            return null;
        }
        static public clsStudentProgress GetLastStudentProgress (int StudentID)
        {
            clsEntityStudentProgress studentProgress = new clsEntityStudentProgress() { StudentID = StudentID };
            if(clsStudentProgressDataAccess.GetLastStudentProgress(studentProgress))
                return new clsStudentProgress(studentProgress);
            return null;
        }
    }
}