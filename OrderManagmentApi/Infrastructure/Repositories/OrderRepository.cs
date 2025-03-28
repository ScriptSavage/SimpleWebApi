using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ProjectContext _context;

    public OrderRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Order>> GetClientOrdersAsync(int clientId)
    {
        var orderData = await _context.Orders
            .Include(e => e.Client).Where(e => e.ClientID == clientId)
            .Include(e => e.OrderProducts)!
            .ThenInclude(e => e.Product)
            .ToListAsync();

        return orderData;
    }

    public async Task<int> CreateOrderAsync(Domain.Entities.Order order)
    {
       await _context.Orders.AddAsync(order);
        var commitData = await _context.SaveChangesAsync();
        return commitData;
    }
}