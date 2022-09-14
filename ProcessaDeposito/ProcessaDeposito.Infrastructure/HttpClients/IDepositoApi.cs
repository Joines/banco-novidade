
using ProcessaDepositos.Infrastructure.Models;
using Refit;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessaDepositos.Infrastructure
{
    public interface IDepositoApi
    {
        [Get("/v3/68cc9f8b-519b-4057-bf3c-804115e68fd4")]
        Task<ICollection<DepositoDTO>> GetDepositList();
    }
}
