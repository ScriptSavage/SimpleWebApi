using Application.Exceptions;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Warehouse;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly ProjectContext _projectContext;

    public WarehouseRepository(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public async Task<int> AddProductToWarehouse(int werehouseId, Product product, int quantity)
    {
        var warehouse = await _projectContext.Warehouse
            .Where(e => e.Id == werehouseId)
            .FirstOrDefaultAsync();

        if (warehouse == null)
        {
            throw new NotFoundException("Warehouse not found");
        }
        
        _projectContext.Products.Add(product);
        var productData = await _projectContext.SaveChangesAsync();

        var warehouseProduct = new WarehouseProduct
        {
            WarehouseId = werehouseId,
            ProductId = product.Id,
            Stock = quantity
        };
        
        _projectContext.WarehouseProducts.Add(warehouseProduct);
        
        var result  = await _projectContext.SaveChangesAsync();

        return result;
    }

    public async Task<int> AddNewWarehouse(Domain.Entities.Warehouse warehouse)
    {
        var dataToAdd = await _projectContext.Warehouse.AddAsync(warehouse);
        var commit = await _projectContext.SaveChangesAsync();
        return commit;
    }
}