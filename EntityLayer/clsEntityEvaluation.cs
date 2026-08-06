using System;

namespace EntityLayer
{
    public class clsEntityEvaluation
    {
        public enum enRate { Weak = 1,Good = 2,VeryGood = 3,Exllant = 4 }
        public enum enEvaluationType { Jazza = 1,Surrah = 2,Aya = 3 }
        public int EvaluationID { get; set; } = -1;
        public int StudentID { get; set; } = -1;
        public short FromAyahID { get; set; } = -1;
        public short ToAyahID { get; set; } = -1;
        public enEvaluationType EvalType { get; set; } = enEvaluationType.Surrah;
        public DateTime EvalDate { get; set; } = DateTime.MinValue;
        public bool IsEvaluationTaken { get; set; } = false;
        public enRate? Rate { get; set; } = null;
        public string Notes { get; set; } = string.Empty;

    }
}