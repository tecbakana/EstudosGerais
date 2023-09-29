using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Implementacao
{
    public class classeConcreta1 : Decorator.DecoratorClass
    {
        public string name = "Concreta 1";
        public classeConcreta1(Concreto.concreteClass cClass) : base(cClass)
        {
        }
        public override string Description()
        {
            return $"{name}->{base.Description()}";
        }
    }
}
