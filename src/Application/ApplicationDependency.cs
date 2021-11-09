using Application.Commands;
using Application.DTOs;
using Application.Mediatr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDependency
    {
        public static void AddApplicationDependency(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateClientCommand, CreateClientResponse>, CreateClientHandler>();
            services.AddScoped<IMediatrHandler, MediatrHandler>();
        }
    }
}
