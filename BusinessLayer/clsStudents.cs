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
        enMode _Mode = enMode.Add;
        public clsEntityStudent EntityStudent = new clsEntityStudent();


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