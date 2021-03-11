using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class PodMapper : IPodMapper
    {
        public InvCommunicaion ToInvCommunication(Pod supplyPoint)
        {
            return new InvCommunicaion() { Id = supplyPoint.Id};
        }
    }
}
