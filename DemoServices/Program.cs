using DemoServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoServices
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        public static void Main(string[] args)
        {
            //configura nossa injeção de dependencia
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IServiceTest, ServiceTest>()
                .AddSingleton<IDemoService, DemoService>()
                .BuildServiceProvider();

            Console.WriteLine("Iniciando aplicacao");

            //realiza operação
            var teste = serviceProvider.GetService<IServiceTest>();
            teste.ServicoTeste();

            Console.WriteLine("Operacao concluída");

            RegisterServices();
            var service = _serviceProvider.GetService<IDemoService>();
            service.ServicoDemo(1);
            Dispose();

            Console.ReadLine();
        }

        public static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IDemoService, DemoService>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        public static void Dispose()
        {
            if (_serviceProvider == null)
                return;

            if(_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
