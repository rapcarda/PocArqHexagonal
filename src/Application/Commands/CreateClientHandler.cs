using Application.Base;
using Application.DTOs;
using Domain.Adapters;
using Domain.Entitties;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateClientHandler : CommandHandlerBase, IRequestHandler<CreateClientCommand, CreateClientResponse>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var response = CreateEmptyResponse();

            if (!request.CommandIsValid()) return ReturnError(response, request.ValidationResult);

            var client = new Client(request.Name, request.Surname, request.Email);
            request.AggregateId = client.Id;

            _clientRepository.AddClient(client);

            var result = await PersistData(_clientRepository.UnitOfWork);

            if (result.IsValid) {
                response.SetValues(client.Id, client.Name, client.Surname, client.Email);
                return response;
            }

            return ReturnError(response, result);
        }

        private CreateClientResponse ReturnError(CreateClientResponse response, ValidationResult validationResult)
        {
            response.SetValidationResult(validationResult);
            return response;
        }

        private CreateClientResponse CreateEmptyResponse()
        {
            return new CreateClientResponse();
        }
    }
}
