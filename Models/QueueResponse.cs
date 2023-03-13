namespace AzureFunctionTester.Models
{
    public class QueueResponse
    {
        public string[] Messages { get; set; }
        public string HttpResponse { get; set; }
    }
}
