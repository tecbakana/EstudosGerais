using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace TopicSender
{
    public class Program
    {
        // connection string to your Service Bus namespace
        static string connectionString = "Endpoint=sb://publishsubscriber74.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5NmlTEWPBHprj9icM0upsZMjeNeuIr+KEJnxuanbMuc=";

        // name of your Service Bus queue
        static string topicName = "topicmediator";

        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient client;

        //envia mensagens para a fila (Queue)
        static ServiceBusSender sender;

        // number of messages to be sent to the topic
        private const int numOfMessages = 3;
        static async Task Main(string[] args)
        {
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(topicName);

            using ServiceBusMessageBatch sbmBatch = await sender.CreateMessageBatchAsync(); 

            for(int i = 1; i <= numOfMessages; i++)
            {
                sbmBatch.TryAddMessage(new ServiceBusMessage($"Message {i}") { To=$"S{i}"});
                Console.WriteLine($"Adicionando mensagem {i} de {numOfMessages}");
            }

            try
            {
                await sender.SendMessagesAsync(sbmBatch);
                Console.WriteLine($"A batch of {numOfMessages} has been sent");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }

            Console.WriteLine("Press any key to end proccess...");
            Console.ReadLine();
        }
    }
}
