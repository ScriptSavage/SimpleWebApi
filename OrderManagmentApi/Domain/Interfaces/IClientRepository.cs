namespace Domain.Interfaces;

public interface IClientRepository
{
    Task<List<Domain.Entities.Client>> GetClientsAsync();
    
    Task<int> AddNewClientAsync(Domain.Entities.Client client);
    
    Task<bool> DoesClientExistAsync(int clientId);
    Task<int> DeleteClientAsync(int clientId);
    
    Task<Domain.Entities.Client> GetClientByIdAsync(int clientId);
}