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
    public class clsStudents
    {
        enum enMode { Add, Update }
        enMode _Mode;
        public clsEntityStudent EntityStudent = new clsEntityStudent();

        public clsStudents()
        {
            EntityStudent.StudentID = -1;
            EntityStudent.FullName = "";
            EntityStudent.BirthDate = DateTime.MaxValue;
            EntityStudent.ParentPhone = "";
            EntityStudent.Address = "";
            EntityStudent.JoinDate = DateTime.Now;
            EntityStudent.IsActive = true;
            EntityStudent.CircleID = -1;
            _Mode = enMode.Add;
        }

        private clsStudents(clsEntityStudent EntityStudent)
        {
            this.EntityStudent = EntityStudent;
            _Mode = enMode.Update;
        }

        private bool AddStudent()
        {
            EntityStudent.StudentID = clsStudentsDataAccess.AddStudent(EntityStudent);
            return EntityStudent.StudentID != default(int);
        }

        public bool UpdateStudent(clsEntityStudent EntityStudent)
        {
            return clsStudentsDataAccess.UpdateStudent(EntityStudent);
        }

        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddStudent();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateStudent(EntityStudent);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }
        static public clsStudents Find(int studentId)
        {
            clsEntityStudent EntityStudent = new clsEntityStudent();
            EntityStudent.StudentID = studentId;

            if (clsStudentsDataAccess.FindStudentByID(EntityStudent))
                return new clsStudents(EntityStudent);
                
            return null;
        }
        public bool DeleteStudent()
        {
            return clsStudentsDataAccess.DeleteStudent(EntityStudent.StudentID);
        }
        static public bool IsStudentExist(int studentId)
        {
            return clsStudentsDataAccess.IsStudentExist(studentId);
        }
        static public DataTable SelectAllStudents()
        {
            return clsStudentsDataAccess.SelectAllStudents();
        }
    }
}