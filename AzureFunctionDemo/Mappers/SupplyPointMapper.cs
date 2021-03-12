using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class SupplyPointMapper<T> : ISupplyPointMapper<T> where T : class
    {
        public InvCommunicaion ToInvCommunication(SupplyPoint supplyPoint)
        {
            return new InvCommunicaion() { Id = supplyPoint.Id };
        }
    }
}
