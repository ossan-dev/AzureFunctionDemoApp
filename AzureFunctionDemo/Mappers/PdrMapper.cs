using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class PdrMapper : SupplyPointMapper
    {
        public override NavSupplyPoint ToSupplyPointStatus(SupplyPoint supplyPoint)
        {
            Pdr pdr = supplyPoint as Pdr;
            return new NavPdr() { Id = supplyPoint.Id, Text = "Pdr text", PdrNo = pdr.PdrNo };
        }
    }
}
