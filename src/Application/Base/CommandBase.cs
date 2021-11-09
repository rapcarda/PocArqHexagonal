using FluentValidation.Results;
using System;

namespace Application.Base
{
    public abstract class CommandBase : MessageBase
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public CommandBase()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool CommandIsValid()
        {
            throw new NotImplementedException();
        }
    }
}
