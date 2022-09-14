using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ProcessaDeposito.Application;
using ProcessaDepositos.Infrastructure.DataProvider;
using System.Runtime.CompilerServices;

namespace ProcessaDepositos.Infrastructure.Extensions
{
    public static class AppServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IDepositoRepository, DepositoRepository>();

            services.AddScoped<IProcessador, Processador>();

            return services;
        }
    }
}
