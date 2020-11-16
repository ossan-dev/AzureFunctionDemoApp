using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionDemo.Services
{
    public interface IGreetingService
    {
        string Hello(string name);
    }
}
