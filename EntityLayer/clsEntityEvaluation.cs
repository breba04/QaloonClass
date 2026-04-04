using System;

namespace EntityLayer
{
    public class clsEntityEvaluation
    {
        public int EvaluationID { get; set; } = -1;
        public int StudentID { get; set; } = -1;
        public short FromAyahID { get; set; } = -1;
        public int ToAyahID { get; set; } = -1;
        public DateTime EvalDate { get; set; } = DateTime.MinValue;
    }
}