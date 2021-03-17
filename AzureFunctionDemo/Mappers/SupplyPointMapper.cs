using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public abstract class SupplyPointMapper : ISupplyPointMapper
    {
        public InvCommunicaion ToInvCommunication(SupplyPoint supplyPoint)
        {
            return new InvCommunicaion() { Id = supplyPoint.Id };
        }

        public virtual NavSupplyPoint ToSupplyPointStatus(SupplyPoint supplyPoint)
        {
            return new NavSupplyPoint()
            { Id = supplyPoint.Id, Text = "This text must not be displayed" };
        }
    }
}
