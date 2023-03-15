using AzureFunctionTester.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionTester.Functions.AzureQueue
{
    public class HttpTriggerWithQueueOutput
    {
        [FunctionName(nameof(HttpTriggerWithQueueOutput))]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Queue("outputQueue", Connection = "AzureWebJobsStorage")] ICollector<QueueResponse> collector, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            collector.Add(new QueueResponse
            {
                HttpResponse = "This is a customized response",
                Messages = new string[] { "utkarsh" }
            });
        }
    }
}
