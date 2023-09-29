using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrincipleIOC
{
    public class IoCSample
    {
        public static void Main(string[] args)
        {
            A a =  new A();
            a.Task1();

            a.Task2();

            a.Task3("Classe A");

            ADI aDI = new ADI(new C());//<-- injected dependency - constructor injection
            aDI.Task1($"Classe {aDI.ToString()}");

            PropertyInjection pi = new PropertyInjection();
            pi.objX = new B();
            pi.Task1($"Classe {pi.objX.GetType().Name}");

            IfaceInjection iInj = new IfaceInjection();
            ((InterfaceInjection)iInj).SetDependency(new C());
            iInj.Task1($"Classe {iInj.GetType().Name}");

            Console.Read();
        }
    }
}
