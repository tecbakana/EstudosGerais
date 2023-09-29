using ConsoleTipoGenerico.Repositorio;
using ConsoleTipoGenerico.Model;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleTipoGenerico
{
    class Program
    {
        public static void Main(string[] args)
        {
            Cliente cli = new Cliente();
            cli.Nome = "Macoratti";

            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var serviceProvider = services.BuildServiceProvider();

            var servico = serviceProvider.GetService<IGenericRepository<Cliente>>();
            servico.Add(cli);          
            
        }
    }
}
