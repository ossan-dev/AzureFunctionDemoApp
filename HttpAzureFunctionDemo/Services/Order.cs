using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpAzureFunctionDemo.Services
{
    public class Order : IOrder
    {
        private readonly ILogger<Order> _logger;

        public Order(ILogger<Order> logger)
        {
            _logger = logger;
        }
        public void Run()
        {
            try
            {
                DemoEntityWrapper test = new DemoEntityWrapper();
                test.DemoEntities.Add(new DemoEntity() { Id = 1, Name = "Ivan" });
                LogContext.PushProperty("OrderId", "1111111");
                LogContext.PushProperty("Status", "OrdStatus");
                _logger.LogInformation("Order - Information");                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "exception during some operation");
            }

        }
    }
}
