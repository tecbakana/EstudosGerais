using MassTransit;
namespace GettingStarted
{
    public class Program
    {

        static void Main(string[] args)
        {
            CreateDefaultBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateDefaultBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<MessageConsumer>();
                 //CONFIGURAÇÃO ORIGINAL MASSTRANSIT
                 /*x.UsingInMemory((context, cfg) =>
                 {
                     cfg.ConfigureEndpoints(context);
                 });*/

                /* CONFIGURAÇÃO AZURE SERVICE BUS */
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    var connectionString = "sb://cmsengine.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=deLbK4aB79xwrLWTJD0QrBgLFlI25D9wS7fsi/0JgtU=";
                    cfg.Host(connectionString);
                    cfg.ConfigureEndpoints(context);
                });
                /*x.UsingAzureServiceBus((context, cfg) =>
                {
                    var connectionString = "sb://cmsengine.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=deLbK4aB79xwrLWTJD0QrBgLFlI25D9wS7fsi/0JgtU=";
                    cfg.Host(connectionString);
                    //cfg.ConfigureEndpoints(context);
                });*/

            });
            services.AddMassTransitHostedService(true);
            services.AddHostedService<Worker>();
        });
    }
}
