using AutoMapper;
using ProcessaDepositos.Domain.Clientes;
using ProcessaDepositos.Infrastructure.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProcessaDepositos.Application.Mappers
{
    public class ClienteMappers : Profile
    {
        public ClienteMappers()
        {
            _ = CreateMap<ClienteDTO, Cliente>()
                .ConstructUsing(src =>
                    new Cliente(src.Id, src.Nome, 
                        src.Agencia, src.Conta));

            _ = CreateMap<ICollection<ClienteDTO>, ListaClientes>()
                .ForMember(dest => dest.Clientes, opts => 
                    opts.MapFrom(src => src));
        }
    }
}
