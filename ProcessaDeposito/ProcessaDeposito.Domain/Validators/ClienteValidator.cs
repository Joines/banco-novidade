using FluentValidation;
using ProcessaDepositos.Domain.Clientes;

namespace ProcessaDeposito.Domain.Validators
{
    public class ClienteValidator: AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Necessário identificação");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome necessário para validar deposito");

            RuleFor(c => c.Agencia)
                .NotEmpty()
                .WithMessage("Agencia necessária para validar deposito");

            RuleFor(c => c.Conta)
                .NotEmpty()
                .WithMessage("Conta necessária para validar deposito");
        }
    }
}
