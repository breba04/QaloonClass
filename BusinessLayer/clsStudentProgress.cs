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
        public clsEntityStudentProgress EntityProgress = new clsEntityStudentProgress();

        public clsStudentProgress()
        {
            EntityProgress.ProgressID = -1;
            EntityProgress.StudentID = -1;
            EntityProgress.AyahID = 0;
            EntityProgress.UpdateDate = DateTime.Now;
            EntityProgress.TeacherID = -1;
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

        public bool UpdateProgress(clsEntityStudentProgress EntityProgress)
        {
            return clsStudentProgressDataAccess.UpdateProgress(EntityProgress);
        }

        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddProgress();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateProgress(EntityProgress);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }

        public bool DeleteProgress()
        {
            return clsStudentProgressDataAccess.DeleteProgress(EntityProgress.ProgressID);
        }

        public DataTable SelectAllProgress()
        {
            return clsStudentProgressDataAccess.SelectAllProgress();
        }
    }
}