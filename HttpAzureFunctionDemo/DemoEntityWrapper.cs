using System;
using System.Collections.Generic;
using System.Text;

namespace HttpAzureFunctionDemo
{
    public class DemoEntityWrapper
    {
        public DemoEntityWrapper()
        {
            DemoEntities = new List<DemoEntity>();
        }
        public List<DemoEntity> DemoEntities { get; set; }
    }
}
