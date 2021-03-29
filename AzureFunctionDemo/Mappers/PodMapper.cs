using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Mappers
{
    public class PodMapper : SupplyPointMapper
    {
        public override NavSupplyPoint ToSupplyPointStatus(SupplyPoint supplyPoint)
        {
            Pod pod = supplyPoint as Pod;
            return new NavPod() { Id = supplyPoint.Id, Text = "Pod Text", PodNo = pod.PodNo  };
        }
    }
}
