using System;

namespace Decorator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite qual objeto deseja carregar: a, b ou c");
            var k = Console.ReadLine();

            ConcreteComponent cc = new ConcreteComponent();
            //Console.WriteLine(cc.Operation());

            ConcreteDecoratorA dcA = new ConcreteDecoratorA(cc);
            //Console.WriteLine(dcA.Operation());

            ConcreteDecoratorB dcB = new ConcreteDecoratorB(dcA);
            //Console.WriteLine(dcB.Operation());

            Client client = new Client();
            //client.ClientCode(dcB);

            Component obj = k switch
            {
                "a" => dcA,
                "b" => dcB,
                _ => cc,
            };

            client.ClientCode(obj);
            Console.WriteLine("Pressione qualquer tecla para finalizar");
            Console.ReadLine();

        }
    }
}
