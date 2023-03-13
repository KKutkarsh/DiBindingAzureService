using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections;

namespace AzureFunctionTester
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Queue("outputQueue", Connection = "AzureWebJobsStorage")] ICollector<MultiResponse> collector, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            collector.Add(new MultiResponse
            {
                HttpResponse = responseMessage,
                Messages = new string[] { "utkarsh" }
            });
        }
    }

    public class MultiResponse
    {
        public string[] Messages { get; set; }
        public string HttpResponse { get; set; }
    }
}
