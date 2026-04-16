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
        public clsEntityStudent EntityStudent;
        public int StudentID { get { return EntityStudent.StudentID; } } 
        public string ParentPhone { get { return EntityStudent.ParentPhone; } }
        public DateTime JoinDate { get { return EntityStudent.JoinDate; }} 
        public clsEntityPerson PersonInfo { get { return EntityStudent.PersonInfo; } }
        public int PersonID { get { return EntityStudent.PersonInfo.PersonID; }  } 
        public DateTime BirthDate { get { return EntityStudent.PersonInfo.BirthDate; } } 
        public string FirstName { get { return EntityStudent.PersonInfo.FirstName; } } 
        public string SecodName { get { return EntityStudent.PersonInfo.SecodName; } } 
        public string ThirdName { get { return EntityStudent.PersonInfo.ThirdName; } } 
        public string LastName { get { return EntityStudent.PersonInfo.LastName; } } 
        public string FullName { get { return EntityStudent.PersonInfo.FullName; } }
        public string Address { get { return EntityStudent.PersonInfo.Address; } }
        public bool IsActive { get { return EntityStudent.PersonInfo.IsActive; } } 

        public int CircleID { get { return EntityStudent.CircleID; } } 
        public clsEntityCircle CircleInfo { get { return EntityStudent.CircleInfo; } } 
        public clsStudents()
        {
            this.EntityStudent = new clsEntityStudent();
            _Mode = enMode.Update;
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
        static public short GetNewStudentsStatsLastMonth()
        {
            return clsStudentsDataAccess.GetNewStudentsStatsLastMonth();
        }
        static public short GetTotalStudentAbsent(DateTime FromDate,DateTime ToDate)
        {
            return clsStudentsDataAccess.GetTotalStudentAbsent(FromDate, ToDate);
        }
        static public short GetTotalStudentAbsentLastMonth()
        {
            DateTime Now = DateTime.Now;
            return GetTotalStudentAbsent(new DateTime(Now.Year, Now.Month, 1), new DateTime(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year,Now.Month)));
        }
    }
}