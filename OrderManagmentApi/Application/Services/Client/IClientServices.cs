using Application.DTO;

namespace Application.Services.Client;

public interface IClientServices
{
    Task<List<ClientDTO>> GetClientsAsync();

    Task<int> AddNewClientDtoAsync(ClientDTO clientDto);
}