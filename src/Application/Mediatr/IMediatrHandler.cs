using Application.Base;
using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Mediatr
{
    public interface IMediatrHandler
    {
        Task<CreateClientResponse> SendCommand<T>(T command) where T : CommandBase;
    }
}
