using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class PodMapper : SupplyPointMapper<Pod>, IPodMapper
    {
        public PodMapper()
        {

        }

        public override NavSupplyPoint ToSupplyPointStatus(SupplyPoint supplyPoint)
        {
            return new NavSupplyPoint() { Id = supplyPoint.Id, Text ="Pod text" };
        }
    }
}
