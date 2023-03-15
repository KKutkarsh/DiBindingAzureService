using AzureFunctionTester.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzureFunctionTester.Functions.AzureQueue
{
    public class HttpTriggerAzureQueueDI
    {
        private readonly IOutputQueueService _outputQueueService;

        public HttpTriggerAzureQueueDI(IOutputQueueService outputQueueService)
        {
            _outputQueueService = outputQueueService;
        }

        [FunctionName(nameof(HttpTriggerAzureQueueDI))]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await _outputQueueService.QueueMessageAsync("text message", new TimeSpan(100));
        }
    }
}
