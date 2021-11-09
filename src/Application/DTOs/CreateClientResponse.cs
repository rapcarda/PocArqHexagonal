using FluentValidation.Results;
using System;

namespace Application.DTOs
{
    public class CreateClientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public CreateClientResponse()
        {
        }

        public void SetValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public void SetValues(Guid id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
