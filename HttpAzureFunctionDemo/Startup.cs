using HttpAzureFunctionDemo;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
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

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            builder.Services.AddLogging(lg => lg.AddSerilog(Log.Logger));
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
