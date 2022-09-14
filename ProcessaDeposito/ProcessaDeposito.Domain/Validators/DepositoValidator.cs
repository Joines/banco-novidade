using FluentValidation;
using ProcessaDepositos.Domain.Clientes;
using ProcessaDepositos.Domain.Transacoes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProcessaDeposito.Domain.Validators
{
    public class DepositoValidator: AbstractValidator<Deposito>
    {
        private static List<Cliente> clientes;
        public DepositoValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .Must(ContaExistente)
                .WithMessage("");
        }

        public static void SetClientes(List<Cliente> clienteList)
        {
            clientes = clienteList;
        }

        private static bool ContaExistente(string id)
        {
            return clientes.Any(c => c.Id.Equals(id));
        }
    }
}
