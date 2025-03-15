namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<Domain.Entities.Order>> GetClientOrdersAsync(int clientId);
    Task<int> CreateOrderAsync(Domain.Entities.Order order);
}