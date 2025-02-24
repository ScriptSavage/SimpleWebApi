using Application.DTO;
using Infrastructure.Repositories.Order;

namespace Application.Services.Order;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<ClientOrdersDTO>> GetClientOrdersAsync(int clientId)
    {
        var orders = await _orderRepository.GetClientOrdersAsync(clientId);

        var result = orders.GroupBy(o => new
            {
                o.Client.FirstName, o.Client.LastName
            })
            .Select(g => new ClientOrdersDTO
            {
                FirstName = g.Key.FirstName,
                LastName = g.Key.LastName,
                OrderDtos = g.Select(e => new OrderDTO
                {
                    CreatedAt = e.CreatedAt,
                    TotalPrice = e.OrderProducts.Sum(p => p.Product.Price*p.Amount),
                    ProductDtos = e.OrderProducts.Select(op => new ProductDTO
                    {
                        Name = op.Product.Name,
                        Price = op.Product.Price,
                        Amount = op.Amount
                    }).ToList()
                }).ToList()
            }).ToList();

        return result;
    }
    


}