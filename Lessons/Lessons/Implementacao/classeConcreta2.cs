using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Implementacao
{
    public class classeConcreta2:Decorator.DecoratorClass
    {
        public string name = "Concreta 2";

        /// <summary>
        /// Injeção de dependencia no construtor
        /// </summary>
        /// <param name="cClass">Classe concreteClass</param>
        public classeConcreta2(Concreto.concreteClass cClass) : base(cClass)
        {
        }
        public override string Description()
        {
            return $"{name}->{base.Description()}";
        }
 
    }
}
