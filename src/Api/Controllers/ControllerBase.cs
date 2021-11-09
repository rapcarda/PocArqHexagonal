using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    public class ControllerBase : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object obj = null)
        {
            if (IsOperationValid()) return Ok(obj);

            if (ErroNotFound()) return NotFound();

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var modelStateErrors = modelState.Values.SelectMany(x => x.Errors);

            foreach (var error in modelStateErrors)
            {
                AddErrors(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddErrors(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult, object obj)
        {
            if (validationResult.IsValid) return CustomResponse(obj);

            return CustomResponse(validationResult);
        }


        protected bool IsOperationValid()
        {
            return !Errors.Any();
        }

        protected void LimparErros()
        {
            Errors.Clear();
        }

        protected void AddErrors(string msgErro)
        {
            Errors.Add(msgErro);
        }

        protected void AdicionarErros(IEnumerable<string> erros)
        {
            foreach (var erro in erros)
            {
                AddErrors(erro);
            }
        }

        private bool ErroNotFound()
        {
            return Errors.Contains("404 - Not Found");
        }
    }
}
