namespace Infrastructure.Repositories.Client;

public interface IClientRepository
{
    Task<List<Domain.Entites.Client>> GetClientsAsync();
    
    Task<int> AddNewClientAsync(Domain.Entites.Client client);
}