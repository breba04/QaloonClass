using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.GlobalClasses
{
    public class AppBootstrap
    {
        static public void Initialize()
        {
            var _ = typeof(clsActivityLogger);
        }
    }
}
