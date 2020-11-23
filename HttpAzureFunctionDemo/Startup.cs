using HttpAzureFunctionDemo;
using HttpAzureFunctionDemo.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using Serilog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace HttpAzureFunctionDemo
{
    public class Startup : FunctionsStartup
    {
        public IConfiguration Configuration { get; set; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.Configure<MyConfiguration>(Configuration.GetSection("MyConfiguration"));
            builder.Services.Configure<MyConfiguration>(Configuration.GetSection("MyConfigurationSecrets"));
            builder.Services.Configure<Serilog>(Configuration.GetSection("Serilog"));

            //var logger = new LoggerConfiguration()
            //.ReadFrom.Configuration(Configuration)
            //.CreateLogger();

            //SelfLog.Enable(msg => Debug.WriteLine(msg));

            //builder.Services.AddLogging(lg =>
            //{
            //    lg.AddSerilog(logger);
            //    SelfLog.Enable(Console.Error);
            //});

            builder.Services.AddScoped<IOrder, Order>();
            builder.Services.AddScoped<IProduct, Product>();

            builder.Services.AddSingleton<ILoggerProvider>(sp => 
            {
                var functionDependencyContext = DependencyContext.Load(typeof(Startup).Assembly);

                //var hostConfig = sp.GetRequiredService<IConfiguration>();

                var logger= new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration, sectionName: "AzureFunctionsJobHost:Serilog", dependencyContext: functionDependencyContext)
                .CreateLogger();

                return new SerilogLoggerProvider(logger, true);
            });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var ctx = builder.GetContext();
            Configuration = builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(ctx.ApplicationRootPath, "local.settings.json"), true, true)
                .AddJsonFile(Path.Combine(ctx.ApplicationRootPath, "appsettings.json"), false, true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true, true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
