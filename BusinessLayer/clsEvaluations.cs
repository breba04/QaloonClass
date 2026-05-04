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
        enMode _Mode;
        clsEntityEvaluation EntityEvaluation ;
        public int EvaluationID { get => EntityEvaluation.EvaluationID; }  
        public int StudentID { get => EntityEvaluation.StudentID; set => EntityEvaluation.StudentID = value; } 
        public short FromAyahID { get => EntityEvaluation.FromAyahID; set => EntityEvaluation.FromAyahID = value; } 
        public int ToAyahID { get => EntityEvaluation.ToAyahID; set => EntityEvaluation.ToAyahID = value; } 
        public DateTime EvalDate { get => EntityEvaluation.EvalDate; set => EntityEvaluation.EvalDate = value; } 
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

        public DataTable SelectAllEvaluations()
        {
            return clsEvaluationsDataAccess.SelectAllEvaluations();
        }
    }
}