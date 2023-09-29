using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaS1.Dependencia
{
    public class xyzCalcManager : ICalculadora
    {
        public int Soma(int a, int b)
        {
            return a + b / 2;
        }
    }
}
