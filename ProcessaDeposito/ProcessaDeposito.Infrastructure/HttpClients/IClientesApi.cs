using ProcessaDepositos.Infrastructure.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessaDepositos.Infrastructure
{
    public interface IClientesApi
    {
        [Get("/v3/7f0acd4b-e63d-4571-b834-c3db15f70673")]
        Task<ICollection<ClienteDTO>> GetClients();
    }
}
