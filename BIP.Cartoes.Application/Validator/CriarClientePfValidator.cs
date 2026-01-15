using BIP.Cartoes.Shared.Contracts.Clientes;
using FluentValidation;

namespace BIP.Cartoes.Application.Validator;

public class CriarClientePfValidator : AbstractValidator<CriarClientePfRequest>
{
    public CriarClientePfValidator()
    {
        RuleFor(x => x.Cpf)
           .NotEmpty()
           .Length(11)
           .Matches("^[0-9]{11}$")
           .WithMessage("CPF deve conter 11 dígitos numéricos.");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.RendaMensal)
            .GreaterThan(0)
            .When(x => x.RendaMensal.HasValue);
    }
}
