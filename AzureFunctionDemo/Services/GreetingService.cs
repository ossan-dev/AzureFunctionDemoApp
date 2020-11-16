using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Services
{
    public class GreetingService : IGreetingService
    {
        public GreetingService()
        {

        }

        public string Hello(string name)
        {
            return $"Hi {name} from the Azure Function";
        }
    }
}
