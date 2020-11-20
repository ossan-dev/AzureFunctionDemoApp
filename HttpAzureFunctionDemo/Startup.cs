using HttpAzureFunctionDemo;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddOptions<MyConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("MyConfiguration").Bind(settings);
                });

            builder.Services.AddOptions<MyConfigurationSecrets>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("MyConfigurationSecrets").Bind(settings);
                });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var ctx = builder.GetContext();
            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(ctx.ApplicationRootPath, "local.settings.json"), true, true)
                .AddJsonFile(Path.Combine(ctx.ApplicationRootPath, "appsettings.json"), false, true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true, true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
