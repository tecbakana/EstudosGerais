using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjecaoDependenciaS1.Dependencia;

namespace InjecaoDependenciaS1
{
    public class ClasseComID
    {
        private readonly ICalculadora _icalculadora;

        public ClasseComID(ICalculadora icalculadora)
        {
            _icalculadora = icalculadora;
        }

        public string RetornaCalculo() => $"O resultado é {_icalculadora.Soma(2, 3)}";

        
    }
}
