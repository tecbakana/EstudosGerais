using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;


namespace SubscriptionReceiver
{
    public class Program
    {
        // connection string to your Service Bus namespace
        static string connectionString = "Endpoint=sb://publishsubscriber74.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5NmlTEWPBHprj9icM0upsZMjeNeuIr+KEJnxuanbMuc=";

        // name of your Service Bus Topic
        static string sbTopic = "topicmediator";

        //name of your Sevice Bus Topic Subscription
        static string sbTopicSubscription = "S2";

        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient client;

        //processador que lê e processa as mensagens da fila (Queue)
        static ServiceBusProcessor processor;


        static async Task Main(string[] args)    
        {
            client = new ServiceBusClient(connectionString);
            processor = client.CreateProcessor(sbTopic, sbTopicSubscription,new ServiceBusProcessorOptions());

            //handlers
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;

            //iniciando leitura
            await processor.StartProcessingAsync();
            Console.WriteLine("Press any key to stop processing...");
            Console.ReadLine();
            await processor.StopProcessingAsync();
            Console.WriteLine("Proccess stoped");

        }

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string msgBody = args.Message.Body.ToString();
            
            Console.WriteLine($"Mensagem recebida:{msgBody} from {sbTopicSubscription} received for {args.Message.To}");

            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());

            return Task.CompletedTask;
        }
    }
}
