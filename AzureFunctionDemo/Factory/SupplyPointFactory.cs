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

        public ISupplyPointMapper GetSupplyPointMapper(object supplyPoint)
        {
            if (supplyPoint is Pod)
                return (ISupplyPointMapper)_serviceProvider.GetService(typeof(PodMapper));
            else
                return (ISupplyPointMapper)_serviceProvider.GetService(typeof(PdrMapper));
            throw new Exception("Object type has to be a SupplyPoint");
        }
    }
}
