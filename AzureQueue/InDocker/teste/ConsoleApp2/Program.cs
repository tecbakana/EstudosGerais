using System;
using System.Threading.Tasks;
using System.Text.Json;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Linq;

namespace StorageQueueApp
{


    class Program
    {
        static async Task Main(string[] args)
        {
            string cnString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";
            cnString = "DefaultEndpointsProtocol=https;AccountName=mystorage74x;AccountKey=n0fxjVxNz0JhkmpPU26e4M5FPD4XrypCnHqkzqEssAeqHRQZcUyPb5EB+652ak6S1sfp1ecL/n7I+AStO8sang==;EndpointSuffix=core.windows.net";
            cnString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";


            string consString = cnString;

            QueueClient queueClient = new QueueClient(consString, "newqueue");
            await queueClient.CreateIfNotExistsAsync();

            bool exitProgram = false;
            while (exitProgram == false)
            {
                Console.WriteLine("What operation would you like to perform?");
                Console.WriteLine("  1 - Send message");
                Console.WriteLine("  2 - Peek at the next message");
                Console.WriteLine("  3 - Receive message");
                Console.WriteLine("  3 - List messages");
                Console.WriteLine("  X - Exit program");

                ConsoleKeyInfo option = Console.ReadKey();

                Console.WriteLine();  // ReadKey does not got the the next line, so this does
                Console.WriteLine();  // Provide some whitespace between the menu and the action

                if (option.KeyChar == '1')
                    await SendMessageAsync(queueClient);
                else if (option.KeyChar == '2')
                    await PeekMessageAsync(queueClient);
                else if (option.KeyChar == '3')
                    await ReceiveMessageAsync(queueClient);
                else if (option.KeyChar == '4')
                    await ListMessageAsync(queueClient);
                else if (option.KeyChar == 'X')
                    exitProgram = true;
                else
                    Console.WriteLine("invalid choice");
            }
        }


        static async Task SendMessageAsync(QueueClient queueClient)
        {
            Console.WriteLine("Enter headline: ");
            string headline = Console.ReadLine();
            Console.WriteLine("Enter location: ");
            string location = Console.ReadLine();
            NewsArticle article = new NewsArticle() { Headline = headline, Location = location };

            string msgJson = JsonSerializer.Serialize(article);
            Response<SendReceipt> response = await queueClient.SendMessageAsync(msgJson);
            SendReceipt sendReceipt = response.Value;
        }


        static async Task PeekMessageAsync(QueueClient queueClient)
        {
            Response<PeekedMessage> response = await queueClient.PeekMessageAsync();

        }

        static async Task ListMessageAsync(QueueClient queueClient)
        {
            var response = await queueClient.ReceiveMessagesAsync(maxMessages: 10);

            response.Value.ToList().ForEach(x =>
            {
                Console.WriteLine($"message id: {x.MessageId}");
                NewsArticle news = x.Body.ToObjectFromJson<NewsArticle>();
                Console.WriteLine($"message Headline: {x.MessageId}");
                Console.WriteLine($"Headline: {news.Headline}");
                Console.WriteLine($"Location: {news.Location}");
                Console.WriteLine($"________________________________");

            });
        }

        static async Task ReceiveMessageAsync(QueueClient queueClient)
        {

            Response<QueueMessage> response = await queueClient.ReceiveMessageAsync();

            QueueMessage message = response.Value;

            try
            {
                Console.WriteLine($"Message.Id{message.MessageId}");
                Console.WriteLine($"Message:{message.Body}");

                NewsArticle newsArticle = message.Body.ToObjectFromJson<NewsArticle>();
                Console.WriteLine("News Article");
                Console.WriteLine($"Headline: {newsArticle.Headline}");
                Console.WriteLine($"Location: {newsArticle.Location}");

                await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
            }
            catch (Exception ex)
            {

            }

        }
    }


    class NewsArticle
    {
        public string Headline { get; set; }
        public string Location { get; set; }
    }


    enum QueueOperation
    {
        SendMessage,
        PeekMessage,
        ReceiveMessage
    }

}
