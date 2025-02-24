using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Client;

public class ClientRepository : IClientRepository
{
    private readonly ProjectContext _context;

    public ClientRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Client>> GetClientsAsync()
    {
        var data = await _context.Clients.ToListAsync();
        return data;
    }

    public async Task<int> AddNewClientAsync(Domain.Entities.Client client)
    {
       await _context.Clients.AddAsync(client);
      var commitData =  await _context.SaveChangesAsync();
       return commitData;
    }

    public async Task<bool> DoesClientExistAsync(int clientId)
    {
        var data = await _context.Clients.AnyAsync(x => x.Id == clientId);
        return data;
    }
}