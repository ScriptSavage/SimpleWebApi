using Domain.DTO;

namespace Application.Services.Interfaces;

public interface IOrderService
{
    Task<List<ClientOrdersDTO>> GetClientOrdersAsync(int clientId);
    Task<int> AddNewOrder(CreateNewOrderDTO order);
}