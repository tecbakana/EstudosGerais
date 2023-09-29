using System;

namespace DemoServices.Services
{
    public class DemoService:IDemoService
    {
        public void ServicoDemo(int numero)
        {
            Console.WriteLine($"Realizando operacao : {numero}");
        }
    }
}
