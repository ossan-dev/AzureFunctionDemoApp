using System;
using System.Collections.Generic;
using System.Text;

namespace HttpAzureFunctionDemo
{
    public class MyConfiguration
    {
        public string Name { get; set; }
        public int AmountOfRetries { get; set; }
        public string KeyToOverride { get; set; }
        public string KeyToNotOverride { get; set; }
        public IEnumerable<string> Authorities { get; set; }
    }
}
