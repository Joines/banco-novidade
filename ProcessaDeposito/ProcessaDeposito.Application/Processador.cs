
using Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessaDeposito.Application
{
    public class Processador: IProcessador
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IDepositoRepository depositoRepository;

        public Processador(IClienteRepository clienteRepository, 
            IDepositoRepository depositoRepository)
        {
            this.clienteRepository = clienteRepository;
            this.depositoRepository = depositoRepository;
        }

        public async Task<bool> ProcessarDepositosAsync(CancellationToken cancellationToken)
        {
            if(!cancellationToken.IsCancellationRequested)
            {
                var depositos = await depositoRepository.ObterDepositosAsync();

                var clientes = await clienteRepository.ObterClientesAsync();

                return true;
            }
            
            return false;
        }
    }
}
