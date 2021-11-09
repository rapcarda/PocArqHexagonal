using Core.Data;
using Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface IClientRepository : IRepository<Client>
    {
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        Task<ICollection<Client>> GetAllClient();
        Task<Client> GetClientById(Guid id);
    }
}
