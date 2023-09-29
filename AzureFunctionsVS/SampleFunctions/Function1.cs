using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SampleFunctions
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("myfirstqueue", Connection = "sb://cmsengine.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=deLbK4aB79xwrLWTJD0QrBgLFlI25D9wS7fsi/0JgtU=")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
