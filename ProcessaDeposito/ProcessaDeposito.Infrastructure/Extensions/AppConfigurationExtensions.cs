using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProcessaDepositos.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessaDepositos.Infrastructure.Extensions
{
    public static class AppConfigurationExtensions
    {
        public static AppConfigurations AddAppConfigs(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddConfiguration<AppConfigurations>(configuration);

            using var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<AppConfigurations>();
        }

        private static IServiceCollection AddConfiguration<TParameterType>(
            this IServiceCollection services,
            IConfiguration configuration,
            string sectionName = null)
            where TParameterType: class, new()
        {
            var section = string.IsNullOrEmpty(sectionName) ?
                configuration :
                configuration.GetSection(sectionName);

            services.Configure<TParameterType>(section);

            services.AddScoped(c =>
                c.GetRequiredService<IOptionsMonitor<TParameterType>>().CurrentValue);

            return services;
        }
    }
}
