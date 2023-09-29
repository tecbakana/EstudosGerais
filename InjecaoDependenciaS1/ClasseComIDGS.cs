using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjecaoDependenciaS1.Dependencia;

namespace InjecaoDependenciaS1
{
    public class ClasseComIDGS
    {
        public ICalculadora icalc { get; set; }

        public string RetornaCalculo() => $"O resultado é {icalc.Soma(9,1)}";
    }
}
