using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public interface IPodMapper
    {
        InvCommunicaion ToInvCommunication(Pod supplyPoint);
    }
}
