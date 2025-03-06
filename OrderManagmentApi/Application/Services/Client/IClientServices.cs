using Domain.DTO;

namespace Application.Services.Client;

public interface IClientServices
{
    Task<List<ClientDTO>> GetClientsAsync();

    Task<int> AddNewClientDtoAsync(ClientDTO clientDto);
    Task<bool> DoesClientExistAsync(int clientId);
    Task<int> DeleteClientAsync(int clientId);
}