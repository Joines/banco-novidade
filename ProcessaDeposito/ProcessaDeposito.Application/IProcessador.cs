using System.Threading;
using System.Threading.Tasks;

namespace ProcessaDeposito.Application
{
    public interface IProcessador
    {
        Task<bool> ProcessarDepositosAsync(CancellationToken stoppingToken);
    }
}