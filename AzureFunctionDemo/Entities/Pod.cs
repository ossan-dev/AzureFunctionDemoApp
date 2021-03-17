using AzureFunctionDemo.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Entities
{
    public class Pod : SupplyPoint
    {
        public string PodNo { get; set; }

        public override Type GetMapper()
        {
            return typeof(PodMapper);
        }
    }
}
