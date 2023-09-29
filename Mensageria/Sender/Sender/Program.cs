using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Sender
{
    public class Program
    {
        // connection string to your Service Bus namespace
        static string connectionString = "Endpoint=sb://cmsengine.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=deLbK4aB79xwrLWTJD0QrBgLFlI25D9wS7fsi/0JgtU=";

        // name of your Service Bus queue
        static string queueName = "myfirstqueue";

        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient client;

        // the sender used to publish messages to the queue
        static ServiceBusSender sender;

        // number of messages to be sent to the queue
        private const int numOfMessages = 3;
        //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            //criando o cliente atribuindo a string de conexão
            client = new ServiceBusClient(connectionString);

            //invocando o metodo sender do cliente
            sender = client.CreateSender(queueName);

            //criando uma batch assincrona com o
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            for(int i=0;i<=100;i++)
            {
                messageBatch.TryAddMessage(new ServiceBusMessage($"Mensagem Numero{i}"));
            }
            

            try
            {
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"Uma batch de {numOfMessages} mensagens foi enviada ao serviço");
            }
            finally

            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
            Console.WriteLine("clique em qualquer tecla para finalizar");
        }
        }
    }
