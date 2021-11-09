using Api.ViewModels;
using Application.Commands;
using Application.Mediatr;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediatrHandler _mediatr;

        public ClientController(IMediatrHandler mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ClientViewModel clientViewModel)
        {
            var command = new CreateClientCommand(clientViewModel.Name, clientViewModel.Surname, clientViewModel.Email);
            var result = await _mediatr.SendCommand(command);

            if (result.ValidationResult != null && !result.ValidationResult.IsValid)
            {
                return CustomResponse(result.ValidationResult);
            }

            return Created(string.Empty, result);
        }
    }
}
