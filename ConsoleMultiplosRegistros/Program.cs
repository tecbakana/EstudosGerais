using ConsoleMultiplosRegistros.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleMultiplosRegistros
{
    class Program
    {
        public static IServiceCollection services = new ServiceCollection();
        public static IServiceCollection srv = new ServiceCollection();
        static void Main(string[] args)
        {
            
            services.AddTransient<IServico, ServicoA>();
            services.AddTransient<IServico, ServicoB>();

            var provider = services.BuildServiceProvider();

            var meusServicos = provider.GetServices<IServico>();
            var meuServico = provider.GetService<IServico>();

            Console.WriteLine("Lista de meus servicos registrados");

            foreach(IServico srv  in meusServicos)
            {
                Console.WriteLine(srv.Servico());
            }

            Console.WriteLine("Meu servico");

            Console.WriteLine(meuServico.Servico());//Pega o ultimo serviço registrado

            Console.WriteLine("Multiplos registros");

            MultiReg();

            Func<int,int> square = x => x * x;

            Console.WriteLine($"Quadrado de 5 é igual a {square(5)}");

            Func<string, int> tamanho = x => x.Length;

            Console.WriteLine($"Mamãe tem  {tamanho("mamae")} caracteres");

            //Func<string, IServiceProvider, IServico> ServiceAlocator = (srv => x => { return x == "A" ? srv.GetService<ServicoA>() : srv.GetService<ServicoB>(); });

            //("A",provider);
        }


        static void MultiReg()
        {
            IServiceCollection srv = new ServiceCollection();

            srv.AddTransient<IServico, ServicoA>();
            srv.AddTransient<IServico, ServicoB>();

            //Func<string,IServico> serviceAlocator = s => Servico();
 
            srv.AddTransient<Func<string,IServico>>(srv => key =>
            { 
                switch(key)
                {
                    case "A":
                        return srv.GetService<ServicoA>();
                    case "B":
                        return srv.GetService<ServicoB>();
                    default:
                        return null;
                }
            });
        }
    }
}
