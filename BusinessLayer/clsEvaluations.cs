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
        clsEntityEvaluation EntityEvaluation = new clsEntityEvaluation();

        public clsEvaluations()
        {
            EntityEvaluation.EvaluationID = -1;
            EntityEvaluation.StudentID = -1;
            EntityEvaluation.FromAyahID = 0; // smallint
            EntityEvaluation.ToAyahID = 0;
            EntityEvaluation.EvalDate = DateTime.Now;
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