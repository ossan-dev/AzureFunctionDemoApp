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
        private readonly ILogger<Function1> _logger;

        public Function1(IGreetingService greetingService, ILogger<Function1> logger)
        {
            _greetingService = greetingService;
            _logger = logger;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer)
        {
            _logger.LogWarning(_greetingService.Hello("ivan"));
        }
    }
}
