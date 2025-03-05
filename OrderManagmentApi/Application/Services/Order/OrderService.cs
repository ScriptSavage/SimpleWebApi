using Application.DTO;
using Application.Exceptions;
using Domain.Entities;
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
    

    public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository, IWarehouseRepository warehouseRepository)
    {
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
        _warehouseRepository = warehouseRepository;
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

    public async Task<int> AddNewOrder(CreateNewOrderDTO order)
    {
        var client = await _clientRepository.GetClientByIdAsync(order.ClientId);
        if (client == null)
        {
            throw new NotFoundException("Client not found");
        }

        var warehouse = await _warehouseRepository.GetWarehouseById(order.WarehouseID);
        if (warehouse == null)
        {
            throw new NotFoundException("Warehouse not found");
        }

        var newOrder = new Domain.Entities.Order
        {
            ClientID = client.Id,
            CreatedAt = DateTime.UtcNow,
            OrderProducts = new List<OrderProduct>()
        };

        decimal totalPrice = 0;

        foreach (var productDto in order.ProductsLists)
        {
            var warehouseProduct = await _warehouseRepository.GetWarehouseProductAsync(warehouse.Id, productDto.ProductId);
            if (warehouseProduct == null)
            {
                throw new NotFoundException($"Product with id {productDto.ProductId} not found in warehouse");
            }

            if (warehouseProduct.Stock < productDto.Quantity)
            {
                throw new BusinessException($"Not enough stock for this product");
            }

            warehouseProduct.Stock -= productDto.Quantity;

          
            decimal unitPrice = warehouseProduct.product.Price;

            totalPrice += unitPrice * productDto.Quantity;

            var orderProduct = new OrderProduct
            {
                ProductId = productDto.ProductId,
                Amount = productDto.Quantity
            };

            newOrder.OrderProducts.Add(orderProduct);
        }

        newOrder.TotalPrice = totalPrice;

        var result = await _orderRepository.CreateOrderAsync(newOrder);

        return result;
    }

}