using Microsoft.Extensions.Logging;
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
            _logger.LogInformation("Order - Information");
            _logger.LogError("Order - Error");
        }
    }
}
