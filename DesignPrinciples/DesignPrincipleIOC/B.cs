using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrincipleIOC
{
    public class B : IObjects.Abstraction
    {
        public void DoSomething()
        {
            ///do something
            Console.WriteLine("this is B itself");
        }

        public void DoAnotherThing()
        {
            Console.WriteLine("I'm instatiated by factory");
        }

        public void ReturnSomething(string parm)
        {
            Console.WriteLine($"I'm DIP in B class [ID:{parm}]");
        }

    }
}
