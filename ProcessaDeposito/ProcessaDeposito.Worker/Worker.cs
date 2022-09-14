using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProcessaDeposito.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessaDeposito.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, 
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                await DoProcessadorAsync(stoppingToken);
            }
        }

        private async Task DoProcessadorAsync(CancellationToken cancellationToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                try
                {
                    IProcessador processador = scope.ServiceProvider.GetRequiredService<IProcessador>();

                    var result = await processador.ProcessarDepositosAsync(cancellationToken);
                }
                catch(Exception ex)
                {
                    _logger.LogWarning(ex, "Falha ao processar depositos");
                }
            }
        }
    }
}
