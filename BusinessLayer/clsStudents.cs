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
        public int StudentID { get  => EntityStudent.StudentID;  } 
        public string ParentPhone { get => EntityStudent.ParentPhone; set => EntityStudent.ParentPhone = value; }
        public DateTime JoinDate { get => EntityStudent.JoinDate; set => EntityStudent.JoinDate = value; } 
        public clsEntityPerson PersonInfo { get => EntityStudent.PersonInfo; set => EntityStudent.PersonInfo = value; }
        public int PersonID { get => EntityStudent.PersonInfo.PersonID; set => EntityStudent.PersonInfo.PersonID = value; } 
        public DateTime BirthDate { get => EntityStudent.PersonInfo.BirthDate; set => EntityStudent.PersonInfo.BirthDate = value; } 
        public string FirstName { get => EntityStudent.PersonInfo.FirstName; set => EntityStudent.PersonInfo.FirstName = value; } 
        public string SecodName { get => EntityStudent.PersonInfo.SecodName; set => EntityStudent.PersonInfo.SecodName = value; } 
        public string ThirdName { get => EntityStudent.PersonInfo.ThirdName; set => EntityStudent.PersonInfo.ThirdName = value; } 
        public string LastName { get => EntityStudent.PersonInfo.LastName; set => EntityStudent.PersonInfo.LastName = value; } 
        public string FullName { get => EntityStudent.PersonInfo.FullName; } 
        public string Address { get => EntityStudent.PersonInfo.Address; set => EntityStudent.PersonInfo.Address = value; } 
        public bool IsActive { get =>EntityStudent.PersonInfo.IsActive; set => EntityStudent.PersonInfo.IsActive = value; } 

        public int CircleID { get => EntityStudent.CircleID; } 
        public clsEntityCircle CircleInfo { get => EntityStudent.CircleInfo; } 
        public string ImagePath { get => EntityStudent.ImagePath; } 
        public clsStudents()
        {
            this.EntityStudent = new clsEntityStudent();
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
            if(clsCurrentUser.CurrentUser.UserRole == (int)clsEntityUser.enUserRole.Admin)
                return clsStudentsDataAccess.SelectAllStudents();
            else
            {
                int CircleID = clsCircles.GetSupervisorByCircleID(clsCurrentUser.CurrentUser.UserID);

                if(CircleID != -1)
                    return clsStudentsDataAccess.SelectAllStudents(CircleID);

                return new DataTable();
            }
        }
        static public short GetNewStudentsStatusLastMonth()
        {
            return clsStudentsDataAccess.GetNewStudentsStatusLastMonth();
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
        static public bool ChangeStudentStatus(int StudentID, bool IsActive)
        {
            return clsStudentsDataAccess.ChangeStudentStatus(StudentID, IsActive);
        }

    }
}