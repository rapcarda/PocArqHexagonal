using Application.Base;
using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class CreateClientCommand : CommandBase, IRequest<CreateClientResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public CreateClientCommand(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public override bool CommandIsValid()
        {
            ValidationResult = new CreateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
