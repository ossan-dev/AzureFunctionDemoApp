using AzureFunctionDemo.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Entities
{
    public class Pdr : SupplyPoint
    {
        public string PdrNo { get; set; }
        public override Type GetMapper()
        {
            return typeof(PdrMapper);
        }
    }
}
