using Application.Repositories;
using AutoMapper;
using ProcessaDepositos.Domain.Clientes;
using Refit;
using System.Net;
using System.Threading.Tasks;

namespace ProcessaDepositos.Infrastructure.DataProvider
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClientesApi api;
        private readonly IMapper mapper;

        public ClienteRepository(IMapper mapper, IClientesApi api)
        {
            this.mapper = mapper;
            this.api = api;
        }

        public async Task<ListaClientes> ObterClientesAsync()
        {
            try
            {
                var listaCliente = await api.GetClients();

                if (listaCliente == null || listaCliente.Count == 0)
                    return null;

                return mapper.Map<ListaClientes>(listaCliente);
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return mapper.Map<ListaClientes>(null);
            }
        }
    }
}
