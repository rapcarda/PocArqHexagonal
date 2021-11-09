using FluentValidation;

namespace Application.Commands
{
    public class CreateClientCommandValidation : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Nome do cliente inválido");

            RuleFor(c => c.Surname)
                .NotNull()
                .WithMessage("Sobrenome do cliente inválido");

            RuleFor(c => c.Email)
                .NotNull()
                .WithMessage("Email do cliente inválido");
        }
    }
}
