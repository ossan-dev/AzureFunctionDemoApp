using Microsoft.Extensions.Logging;
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
            _logger.LogInformation("Product - Information");
            _logger.LogError("Product - Error");
        }
    }
}
