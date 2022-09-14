using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProcessaDepositos.Infrastructure.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(
            this IServiceCollection services,
            params string[] namespaces)
        {
            _ = namespaces ??
                throw new ArgumentNullException(nameof(namespaces));

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddMaps(namespaces);
            });

            configuration.AssertConfigurationIsValid();
            services.AddSingleton(configuration.CreateMapper());

            return services;
        }
    }
}
