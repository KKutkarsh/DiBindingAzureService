using AzureFunctionTester.Interface;
using AzureQueueService;

namespace AzureFunctionTester
{
    public class OutputQueueService : AzureQueue, IOutputQueueService
    {
        public OutputQueueService(string connectionString, string queueName):base(connectionString,queueName)
        {
        }
    }
}
