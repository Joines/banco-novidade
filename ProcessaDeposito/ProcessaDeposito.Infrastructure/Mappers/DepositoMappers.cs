using AutoMapper;
using ProcessaDepositos.Domain.Transacoes;
using ProcessaDepositos.Infrastructure.Models;
using System.Collections;
using System.Collections.Generic;

namespace ProcessaDepositos.Infrastructure.Mappers
{
    public class DepositoMappers : Profile
    {
        public DepositoMappers()
        {
            _ = CreateMap<DepositoDTO, Deposito>()
                .ConstructUsing(src =>
                new Deposito(src.Id, src.Nome, src.AgenciaDestino,
                    src.ContaDestino, src.AgenciaOrigem, src.ContaOrigem, 
                    src.Valor, src.DataTransacao));

            _ = CreateMap<ICollection<DepositoDTO>, RelacaoDeposito>()
                .ForMember(dest => dest.Depositos, opts => 
                    opts.MapFrom(src => src));
        }
    }
}
