using System;
using AzureFunctionDemo.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo
{
    public class Function1
    {
        private readonly IGreetingService _greetingService;

        public Function1(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation(_greetingService.Hello("ivan"));
        }
    }
}
