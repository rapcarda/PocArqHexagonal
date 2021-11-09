using Domain.Adapters;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class InfraDependency
    {
        public static void AddInfraDependency(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<PocContext>();
        }
    }
}
