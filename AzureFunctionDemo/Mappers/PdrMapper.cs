using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class PdrMapper : IPdrMapper
    {
        public InvCommunicaion ToInvCommunication(Pdr supplyPoint)
        {
            return new InvCommunicaion() { Id = supplyPoint.Id };
        }
    }
}
