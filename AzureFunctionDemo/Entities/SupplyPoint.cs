using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Entities
{
    public abstract class SupplyPoint
    {
        public Guid Id { get; set; }
        public DateTime InsertDate { get; set; }

        public abstract Type GetMapper();
    }
}
