using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Entities
{
    public class SupplyPoint
    {
        public Guid Id { get; set; }
        public DateTime InsertDate { get; set; }


        public virtual string GetInfo()
        {
            return "This text must not be print!";
        }
    }
}
