using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcessaDepositos.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessaDeposito.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var envName = hostingContext.HostingEnvironment
                        .EnvironmentName;

                    config.AddJsonFile($"appsettings.json",
                            optional: false, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{envName}.json",
                            optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var appConfigs = services.AddAppConfigs(hostContext.Configuration);
                    services.AddAutoMapper("ProcessaDeposito.Infrastructure");
                    services.AddAppServices();
                    services.AddHttpClients(appConfigs);
                    services.AddHostedService<Worker>();
                });
    }
}
