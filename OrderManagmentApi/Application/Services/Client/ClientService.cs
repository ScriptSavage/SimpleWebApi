using Application.DTO;
using Infrastructure.Repositories.Client;

namespace Application.Services.Client;

public class ClientService : IClientServices
{
    
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientDTO>> GetClientsAsync()
    {
        var clientsData = await _clientRepository.GetClientsAsync();

        var clients = clientsData
            .Select(e => new ClientDTO
            {
            FirstName = e.FirstName,
            LastName = e.LastName,
            }).ToList();

        return clients;
    }
}