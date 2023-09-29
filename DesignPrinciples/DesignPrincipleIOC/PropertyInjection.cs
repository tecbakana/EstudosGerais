using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPrincipleIOC.IObjects;

namespace DesignPrincipleIOC
{
    public class PropertyInjection //Dependency Injection <-- property
    {
        public Abstraction objX { get; set; }

        public PropertyInjection()
        {

        }

        public void Task1(string parm)
        {
            objX.ReturnSomething(parm);
        }
    }
}
