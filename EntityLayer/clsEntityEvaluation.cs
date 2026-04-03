using System;

namespace EntityLayer
{
    public class clsEntityEvaluation
    {
        public int EvaluationID { get; set; }
        public int StudentID { get; set; }
        public short FromAyahID { get; set; }
        public int ToAyahID { get; set; }
        public DateTime EvalDate { get; set; }
    }
}