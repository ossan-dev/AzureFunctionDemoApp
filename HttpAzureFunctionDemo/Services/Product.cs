using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpAzureFunctionDemo.Services
{
    public class Product : IProduct
    {
        private readonly ILogger<Product> _logger;

        public Product(ILogger<Product> logger)
        {
            _logger = logger;
        }
        public void Run()
        {
            LogContext.PushProperty("ProductId", "2222222");
            LogContext.PushProperty("Status", "ProdStatus");
            _logger.LogInformation("Product - Information");
            _logger.LogError("Product - Error");
        }
    }
}
