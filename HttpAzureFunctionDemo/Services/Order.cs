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
            LogContext.PushProperty("OrderId", "1111111");
            LogContext.PushProperty("Status", "OrdStatus");
            _logger.LogInformation("Order - Information");
            _logger.LogError("Order - Error");
        }
    }
}
