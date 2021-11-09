using Application.Base;
using Application.DTOs;
using MediatR;
using System.Threading.Tasks;

namespace Application.Mediatr
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CreateClientResponse> SendCommand<T>(T command) where T : CommandBase
        {
            return (CreateClientResponse)await _mediator.Send(command);
        }
    }
}
