using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class SupplyPointMapper<T> : ISupplyPointMapper<T> where T : SupplyPoint
    {
        public InvCommunicaion ToInvCommunication(SupplyPoint supplyPoint)
        {
            return new InvCommunicaion() { Id = supplyPoint.Id };
        }

        public NavSupplyPoint ToSupplyPointStatus(SupplyPoint supplyPoint)
        {
            return new NavSupplyPoint()
            { Id = supplyPoint.Id, Text = supplyPoint.GetInfo() };
        }
    }
}
