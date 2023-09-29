using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Decorator
{
    public class DecoratorClass:Concreto.concreteClass
    {
        private Concreto.concreteClass _concreteClass;

        public DecoratorClass(Concreto.concreteClass concreteClass)
        {
            this._concreteClass = concreteClass;
        }

        public void SetDecorator(Concreto.concreteClass concreteClass)
        {
            this._concreteClass = concreteClass;
        }

        public override string Description()
        {
            if(this._concreteClass != null)
            {
                return this._concreteClass.Description();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
