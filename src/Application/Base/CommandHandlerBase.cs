using Core.Data;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Application.Base
{
    public abstract class CommandHandlerBase
    {
        public ValidationResult ValidationResult { get; set; }

        public CommandHandlerBase()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddErrorValidation(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> PersistData(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork.Commit()) AddErrorValidation("Houve um erro ao persistir os dados");
            return ValidationResult;
        }
    }
}
