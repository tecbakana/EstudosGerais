using TempoDeVida.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TempoDeVida
{
    class Program
    {
        private static IServiceCollection _serviceCollection = new ServiceCollection();
        static void Main(string[] args)
        {

            RegisterService();
            TesteEscopo();
            TesteEscopo2();
            

        }

        public static void RegisterService()
        {
            //adicionando servicos
            _serviceCollection.AddTransient<TransientOperacao>();
            _serviceCollection.AddScoped<ScopedOperacao>();
            _serviceCollection.AddSingleton<SingletonOperacao>();
        }

        public static void TesteEscopo()
        {
            //construindo o container
            var service = _serviceCollection.BuildServiceProvider();

            Console.WriteLine("Primeiro Request");

            //primeira requisicao
            var trn1 = service.GetService<TransientOperacao>();
            var scp1 = service.GetService<ScopedOperacao>();
            var sgl1 = service.GetService<SingletonOperacao>();

            Console.WriteLine("Segundo Request");

            var trn2 = service.GetService<TransientOperacao>();
            var scp2 = service.GetService<ScopedOperacao>();
            var sgl2 = service.GetService<SingletonOperacao>();

            

            Console.WriteLine();
            Console.WriteLine(new String('-', 30));
            Console.ReadLine();
        }

        public static void TesteEscopo2()
        {
            //construindo o container
            var service = _serviceCollection.BuildServiceProvider();

            Console.WriteLine("Primeiro Request - Escopo 1");

            using (var scope = service.CreateScope())
            {
                //primeira requisicao
                var trn1 = scope.ServiceProvider.GetService<TransientOperacao>();
                var scp1 = scope.ServiceProvider.GetService<ScopedOperacao>();
                var sgl1 = scope.ServiceProvider.GetService<SingletonOperacao>();
            }

            Console.WriteLine("Segundo Request - Escopo 2");
            using (var scope = service.CreateScope())
            {
                var trn2 = scope.ServiceProvider.GetService<TransientOperacao>();
                var scp2 = scope.ServiceProvider.GetService<ScopedOperacao>();
                var sgl2 = scope.ServiceProvider.GetService<SingletonOperacao>();
            }

            
            Console.WriteLine();
            Console.WriteLine(new String('-', 30));
            Console.ReadLine();
        }

        public static void Dispose()
        {
            if(_serviceCollection == null)
            {
                return;
            }

            if(_serviceCollection is IDisposable)
            {
                ((IDisposable)_serviceCollection).Dispose();
            }
        }
    }
}
