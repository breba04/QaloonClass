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
    public class clsEvaluations
    {
        enum enMode { Add, Update }
        public enum enGrade { NotRecordedYet=0, Poor =1, Good , VeryGood, Excellent }
        public enum enEvaluationType { Joza =1, Surrah , VeryGood, Random }
        enMode _Mode;
        clsEntityEvaluation EntityEvaluation ;
        public int EvaluationID { get => EntityEvaluation.EvaluationID; }  
        public int StudentID { get => EntityEvaluation.StudentID; set => EntityEvaluation.StudentID = value; } 
        public short FromAyahID { get => EntityEvaluation.FromAyahID; set => EntityEvaluation.FromAyahID = value; } 
        public short ToAyahID { get => EntityEvaluation.ToAyahID; set => EntityEvaluation.ToAyahID = value; } 
        public byte EvalType { get => EntityEvaluation.EvalType; set => EntityEvaluation.EvalType = value; }
        public DateTime EvalDate { get => EntityEvaluation.EvalDate; set => EntityEvaluation.EvalDate = value; }
        public bool IsEvaluationTaken { get => EntityEvaluation.IsEvaluationTaken; set => EntityEvaluation.IsEvaluationTaken = value; }
        public byte? Rate { get => EntityEvaluation.Rate; set => EntityEvaluation.Rate = value; }
        public string Notes { get => EntityEvaluation.Notes; set => EntityEvaluation.Notes = value; }
        public clsEvaluations()
        {
            EntityEvaluation = new clsEntityEvaluation();
            _Mode = enMode.Add;
        }

        private clsEvaluations(clsEntityEvaluation EntityEvaluation)
        {
            this.EntityEvaluation = EntityEvaluation;
            _Mode = enMode.Update;
        }

        private bool AddEvaluation()
        {
            EntityEvaluation.EvaluationID = clsEvaluationsDataAccess.AddEvaluation(EntityEvaluation);
            return EntityEvaluation.EvaluationID != default(int);
        }

        public bool UpdateEvaluation(clsEntityEvaluation EntityEvaluation)
        {
            return clsEvaluationsDataAccess.UpdateEvaluation(EntityEvaluation);
        }

        public bool Save()
        {
            if (_Mode == enMode.Add)
            {
                return AddEvaluation();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdateEvaluation(EntityEvaluation);
            }
            else
            {
                throw new Exception("Invalid mode");
            }
        }

        public bool DeleteEvaluation()
        {
            return clsEvaluationsDataAccess.DeleteEvaluation(EntityEvaluation.EvaluationID);
        }

        static public DataTable SelectAllEvaluations(DateTime From,DateTime To)
        {
            return clsEvaluationsDataAccess.SelectAllEvaluations(From,To);
        }
        static public DataTable SelectAllTestType()
        {
            return clsEvaluationsDataAccess.SelectAllTestType();
        }
        static public clsEvaluations FindEvaluation(int evaluationID)
        {
            clsEntityEvaluation evaluation = new clsEntityEvaluation() { EvaluationID = evaluationID};
            if (clsEvaluationsDataAccess.FindEvaluation(evaluation))
                return new clsEvaluations(evaluation);
            return null;

        }
    }
}