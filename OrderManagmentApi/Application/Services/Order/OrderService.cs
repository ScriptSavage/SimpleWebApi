using Application.DTO;
using Application.Exceptions;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Client;
using Infrastructure.Repositories.Order;
using Infrastructure.Repositories.Warehouse;

namespace Application.Services.Order;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IProductRepository _productRepository;
    

    public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository, IWarehouseRepository warehouseRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
        _warehouseRepository = warehouseRepository;
        _productRepository = productRepository;
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

    public async Task<int> GetClientOrderAsync(CreateNewOrderDTO order)
    {
        var client = await _clientRepository.GetClientByIdAsync(order.ClientId);

        var warehouse = await _warehouseRepository.GetWarehouseById(order.WarehouseID);
        

        foreach (var item in order.ProductsLists)
        {
            // var warehouseProduct = await _warehouseRepository.GetWarehouseProductAsync(order.WarehouseID, item.ProductId);
            // if (warehouseProduct == null)
            //     throw new NotFoundException($"Product with ID {item.ProductId} is not available in warehouse");
            //
            // if (warehouseProduct.Stock < item.Quantity)
            //     throw new BusinessException($"Insufficient stock for product ID {item.ProductId}");

            
        }
        
        var makeNewOrder = new Domain.Entities.Order
        {
            
        };
       var result =   await _orderRepository.CreateOrderAsync(makeNewOrder);
      

      
        var orderDto = new OrderDTO
        {
            CreatedAt = DateTime.Now,
            
        };
        return result;
        
    }
}