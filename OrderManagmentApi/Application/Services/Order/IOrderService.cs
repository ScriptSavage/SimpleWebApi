using Application.DTO;

namespace Application.Services.Order;

public interface IOrderService
{
    Task<List<ClientOrdersDTO>> GetClientOrdersAsync(int clientId);
    Task<int> GetClientOrderAsync(CreateNewOrderDTO order);
}