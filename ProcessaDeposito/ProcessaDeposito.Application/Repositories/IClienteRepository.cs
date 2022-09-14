using ProcessaDepositos.Domain.Clientes;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IClienteRepository
    {
        Task<ListaClientes> ObterClientesAsync();
    }
}
