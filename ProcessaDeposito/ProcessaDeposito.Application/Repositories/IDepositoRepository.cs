using ProcessaDepositos.Domain.Transacoes;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IDepositoRepository
    {
        Task<RelacaoDeposito> ObterDepositosAsync();
    }
}
