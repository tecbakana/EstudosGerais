using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Receiver
{
    public class Program
    {
        // connection string to your Service Bus namespace
        static string connectionString = "Endpoint=sb://cmsengine.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=deLbK4aB79xwrLWTJD0QrBgLFlI25D9wS7fsi/0JgtU=";

        // name of your Service Bus queue
        static string queueName = "myfirstqueue";

        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient client;

        //processador que lê e processa as mensagens da fila (Queue)
        static ServiceBusProcessor processor;
        static async Task Main(string[] args)
        {

            client = new ServiceBusClient(connectionString);
            processor = client.CreateProcessor(queueName,new ServiceBusProcessorOptions());

            try
            {
                //adicionando o manipulador da mensagem Handler
                processor.ProcessMessageAsync += MessageHandler;

                //adicionando o manipulador de erro Handler
                processor.ProcessErrorAsync += ErrorHandler;

                //iniciando o processamento das mensagens
                await processor.StartProcessingAsync();

                Console.WriteLine("Pressione qualquer tecla para finalizar o processamento");
                Console.ReadKey();
                Console.WriteLine("...parando o processamento");
                await processor.StopProcessingAsync();
                Console.WriteLine("processamento encerrado");

                
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync(); 
            }
        }

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string msgBody = args.Message.Body.ToString();
            Console.WriteLine($"Mensagem recebida:{msgBody}");

            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());

            return Task.CompletedTask;
        }

    }
}
