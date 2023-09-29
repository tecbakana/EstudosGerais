using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Implementacao
{
    public class client
    {
        public void ClientCode(Decorator.DecoratorClass dclass)
        {
            Console.WriteLine($"Client code:{dclass.Description()}");
        }
    }
}
