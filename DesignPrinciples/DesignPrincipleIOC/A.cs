using DesignPrincipleIOC.IObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrincipleIOC
{
    public class A
    {
        B b;
        Abstraction iObj;
        public A()
        {
            b = new B();
        }

        public void Task1()
        {
            b.DoSomething();
        }

        public void Task2()
        {
            var nB = Factory.GetObject();//IoC <-- Factory
            nB.DoAnotherThing();
        }

        public void Task3(string parm)
        {
            iObj = IFactory.GetObject();
            iObj.ReturnSomething(parm);
            iObj.DoSomething();
        }
    }
}
