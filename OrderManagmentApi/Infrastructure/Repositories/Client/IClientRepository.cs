namespace Infrastructure.Repositories.Client;

public interface IClientRepository
{
    Task<List<Domain.Entities.Client>> GetClientsAsync();
    
    Task<int> AddNewClientAsync(Domain.Entities.Client client);
    
    Task<bool> DoesClientExistAsync(int clientId);
}