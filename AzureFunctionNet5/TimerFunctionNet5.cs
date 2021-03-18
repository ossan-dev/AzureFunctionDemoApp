using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionNet5
{
    public static class TimerFunctionNet5
    {
        const string _timerCron = "*/15 * * * * *";

        [Function("TimerFunctionNet5")]
        public static void Run([TimerTrigger(_timerCron)] MyInfo myTimer, FunctionContext context)
        {
            var logger = context.GetLogger("TimerFunctionNet5");
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
