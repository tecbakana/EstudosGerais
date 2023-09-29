using System;
using InjecaoDependenciaS1.Dependencia;

namespace InjecaoDependenciaS1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Construtor classico, altamente acoplado");
            ClasseSemID csid = new ClasseSemID();
            Console.WriteLine(csid.RetornaCalculo());

            Console.WriteLine("Injeção de dependencia no construtor");
            var ccid = new ClasseComID(new xptoCalculadora());
            Console.WriteLine(ccid.RetornaCalculo());

            Console.WriteLine("Injeção de dependencia com getter & setter");
            var xptc = new xyzCalcManager();
            ClasseComIDGS ccidgs = new ClasseComIDGS()
            {
                icalc = xptc
            };
            Console.WriteLine(ccidgs.RetornaCalculo());

            Console.WriteLine("Injeção de dependencia com Method Injection");
            var xCalc = new xptoCalculadora();// new xyzCalcManager();
            ClasseComIDMI ccidmi = new ClasseComIDMI();
            Console.WriteLine(ccidmi.RetornaCalculo(xCalc));
        }
    }
}
