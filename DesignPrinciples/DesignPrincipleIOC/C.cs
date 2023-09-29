using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrincipleIOC
{
    public class C : IObjects.Abstraction
    { 
        public void DoSomething()
        {
            ///do something
            Console.WriteLine("this is C itself");
        }

        public void DoAnotherThing()
        {
            Console.WriteLine("I'm instatiated by factory");
        }

        public void ReturnSomething(string parm)
        {
            Console.WriteLine($"I'm DIP in C class [ID:{parm}]");
        }
    }
}
