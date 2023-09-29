using DemoServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoServices
{
    public class StartUp
    {
        public static IServiceProvider RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IDemoService, DemoService>();
            return collection.BuildServiceProvider();
        }

    }
}
