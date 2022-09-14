using Microsoft.Extensions.DependencyInjection;
using ProcessaDepositos.Infrastructure.Configurations;
using Refit;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProcessaDepositos.Infrastructure.Extensions
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddHttpClients(
            this IServiceCollection services,
            AppConfigurations appConfigs)
        {
            services.AddClient<IClientesApi>("ClienteApi", appConfigs);
            services.AddClient<IDepositoApi>("DepositoApi", appConfigs);

            return services;
        }

        private static IServiceCollection AddClient<TClient>(
            this IServiceCollection services,
            string name,
            AppConfigurations appConfig)
            where TClient: class
        {
            var httpConfigs = appConfig.HttpClients
                .Single(s => string.Equals(s.Name, name));

            var uri = GetBaseAddress(appConfig, httpConfigs);

            services.AddHttpClient<TClient>(httpConfigs.Name, client =>
            {
                client.BaseAddress = uri;
            })
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHandler)
            .AddTypedClient(client =>
                RestService.For<TClient>(client, RefitJsonSettings()));

            return services;
        }

        private static HttpClientHandler ConfigurePrimaryHandler()
        {
            return new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
        }

        public static Uri GetBaseAddress(
            AppConfigurations appConfigs,
            HttpClientConfiguration httpConfigs)
        {
            var baseAddress = httpConfigs.BaseAddress switch
            {
                nameof(AppConfigurations.HostBaseAddress) =>
                    appConfigs.HostBaseAddress,

                _ => throw new ArgumentException("invalid base address", nameof(appConfigs))
            };

            return new Uri(baseAddress);
        }

        private static RefitSettings RefitJsonSettings()
        {
            var jsonOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false,
                PropertyNameCaseInsensitive = true
            };

            jsonOptions.Converters
                .Add(new JsonStringEnumConverter());

            var settings = new RefitSettings()
            {
                ContentSerializer =
                    new SystemTextJsonContentSerializer(jsonOptions)
            };

            return settings;
        }
    }
}
