using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPrincipleIOC.IObjects;

namespace DesignPrincipleIOC
{
    interface InterfaceInjection
    {
        void SetDependency(Abstraction abstraction);
    }

    public class IfaceInjection : InterfaceInjection
    {
        Abstraction _abstraction;
        public IfaceInjection()
        {

        }

        public void Task1(string parm)
        {
            _abstraction.ReturnSomething(parm);
        }

        public void SetDependency(Abstraction abstraction)
        {
            _abstraction = abstraction;
        }
    }
}
