using Application.DTO;
using Infrastructure.Repositories.Warehouse;

namespace Application.Services.Warehouse;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<int> AddNewProductToWarehouse(int warehouseId, NewProductDTO product ,int quantity)
    {
        var newProduct = new Domain.Entites.Product()
        {
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            
        };
        var warehouseToAdd = await _warehouseRepository.AddWarehouseProdcutAsync(warehouseId, newProduct,quantity);

        return warehouseToAdd;
    }
}