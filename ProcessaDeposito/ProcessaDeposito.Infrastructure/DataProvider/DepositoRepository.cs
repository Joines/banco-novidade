
using AutoMapper;
using Application.Repositories;
using ProcessaDepositos.Domain.Transacoes;
using ProcessaDepositos.Infrastructure.Models;
using Refit;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net;
using System.Threading.Tasks;

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ProcessaDepositos.Infrastructure.DataProvider
{
    public class DepositoRepository : IDepositoRepository
    {
        private readonly IDepositoApi api;
        private readonly IMapper mapper;

        public DepositoRepository(IDepositoApi api,
            IMapper mapper)
        {
            this.api = api;
            this.mapper = mapper;
        }

        public async Task<RelacaoDeposito> ObterDepositosAsync()
        {
            try
            {
                var result = await api.GetDepositList();

                if (result == null)
                    return null;

                var response = mapper.Map<RelacaoDeposito>(result);

                return response;
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return mapper.Map<RelacaoDeposito>(null);
            }
        }
    }
}
