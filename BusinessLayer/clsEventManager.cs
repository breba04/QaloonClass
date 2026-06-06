using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    static public class clsEventManager
    {
        public static event EventHandler<clsEntityEvaluation> EvaluationAdded;
        public static event EventHandler<clsEntityStudent> StudentAdded;
        public static event EventHandler<clsEntityActivityLog> ActivityAdded;
        static clsEventManager()
        {
            //var logger = new clsActivityLogger();//ActivityAdded للاشتراك في حدث 
        }
            
        static public void OnEvaluationAdded(object sendor,clsEntityEvaluation e)
        {
            EvaluationAdded?.Invoke(sendor, e);
        }
        static public void OnStudentAdded(object sendor,clsEntityStudent e)
        {
            StudentAdded?.Invoke(sendor, e);
        }
        static public void OnActivityAdded(object sendor,clsEntityActivityLog e)
        {
            ActivityAdded?.Invoke(sendor, e);
        }
    }
}
