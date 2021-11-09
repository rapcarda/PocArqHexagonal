using Core.Data;
using Domain.Adapters;
using Domain.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PocContext _context;

        public ClientRepository(PocContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AddClient(Client client)
        {
            _context.Add(client);
        }

        public void UpdateClient(Client client)
        {
            _context.Update(client);
        }

        public void DeleteClient(Client client)
        {
            _context.Remove(client);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<ICollection<Client>> GetAllClient()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        
    }
}
