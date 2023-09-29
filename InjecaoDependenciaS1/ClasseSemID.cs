using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjecaoDependenciaS1.Dependencia;

namespace InjecaoDependenciaS1
{
    public class ClasseSemID
    {
        public string RetornaCalculo()
        {
            xptoCalculadora xpto = new xptoCalculadora();
            var res = xpto.Soma(2, 2);
            return $"O resultado de 2+2 é {res}";
        }
    }
}
