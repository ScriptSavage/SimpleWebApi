namespace Infrastructure.Repositories.Order;

public interface IOrderRepository
{
    Task<List<Domain.Entites.Order>> GetClientOrdersAsync(int clientId);
}