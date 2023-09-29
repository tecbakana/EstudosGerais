using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;

namespace ManageMessage
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string consString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";
            QueueClient queueClient = new QueueClient(consString, "newQueue");
            await queueClient.CreateIfNotExistsAsync();
        }
    }
}
