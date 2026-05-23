using System;

namespace EntityLayer
{
    public class clsEntityEvaluation
    {
        public int EvaluationID { get; set; } = -1;
        public int StudentID { get; set; } = -1;
        public short FromAyahID { get; set; } = -1;
        public short ToAyahID { get; set; } = -1;
        public byte EvalType { get; set; } = 0;
        public DateTime EvalDate { get; set; } = DateTime.MinValue;
        public bool IsEvaluationTaken { get; set; } = false;
        public byte? Rate { get; set; } = null;
        public string Notes { get; set; } = string.Empty;

    }
}