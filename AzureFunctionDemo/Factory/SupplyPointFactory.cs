using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Factory
{
    public class SupplyPointFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SupplyPointFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISupplyPointMapper GetSupplyPointMapper(SupplyPoint supplyPoint)
        {
            return (ISupplyPointMapper)_serviceProvider.GetService(supplyPoint.GetMapper());
        }
    }
}
