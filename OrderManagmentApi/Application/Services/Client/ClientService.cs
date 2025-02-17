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
}