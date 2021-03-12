using AzureFunctionDemo;
using AzureFunctionDemo.Mappers;
using AzureFunctionDemo.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunctionDemo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"C:\\temp\\logIvan.txt")
                .MinimumLevel.Warning()
                .CreateLogger();

            builder.Services.AddLogging(lg => lg.AddSerilog(logger));
            builder.Services.AddScoped<IGreetingService, GreetingService>();

            //builder.Services.AddScoped<IPodMapper, PodMapper>();
            //builder.Services.AddScoped<IPdrMapper, PdrMapper>();

            builder.Services.AddScoped(typeof(ISupplyPointMapper<>), typeof(SupplyPointMapper<>));
        }
    }
}
