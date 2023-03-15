using AzureFunctionTester.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureFunctionTester.Helpers
{
    public static class BootstrapAzureQueues
    {
        public static IServiceCollection AddOutputQueue(this IServiceCollection services)
        {
            Func<IServiceProvider, IOutputQueueService> factory = (serviceProvider) =>
            {
                //IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
                //EnvironmentHelper environmentHelper = configuration.Get<EnvironmentHelper>();
                return new OutputQueueService("can get it from env variable", "some constant or env variable");
            };

            return services.AddSingleton(factory);
        }
    }
}
