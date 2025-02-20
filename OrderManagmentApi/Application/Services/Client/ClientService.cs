using Application.DTO;
using Infrastructure.Repositories.Client;
using Microsoft.Extensions.Logging;

namespace Application.Services.Client;

public class ClientService : IClientServices
{
    
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<ClientService> _clientLogger;

    public ClientService(IClientRepository clientRepository, ILogger<ClientService> clientLogger)
    {
        _clientRepository = clientRepository;
        _clientLogger = clientLogger;
    }

    public async Task<List<ClientDTO>> GetClientsAsync()
    {
        var clientsData = await _clientRepository.GetClientsAsync();
        _clientLogger.LogInformation("Client data retrieved successfully");

        var clients = clientsData.Select(e => new ClientDTO
        {

            FirstName = e.FirstName,
            LastName = e.LastName,
        }).ToList();

        return clients;
    }

    public async Task<int> AddNewClientDtoAsync(ClientDTO clientDto)
    {
      
        
        var newClientToAdd = new Domain.Entites.Client()
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName
        };
        
        var clientRepo = await _clientRepository.AddNewClientAsync(newClientToAdd);
        
       return clientRepo;
    }

    public async Task<bool> DoesClientExistAsync(int clientId)
    {
        var data = await _clientRepository.DoesClientExistAsync(clientId);
        return data;
    }
}