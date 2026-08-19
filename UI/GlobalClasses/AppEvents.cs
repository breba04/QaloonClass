using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.GlobalClasses
{
    public class clsAppEvents
    {
        public static event EventHandler StudentAdded;
        public static void OnStudentAdded()
        {
            StudentAdded?.Invoke(null, EventArgs.Empty);
        }
    }
}
