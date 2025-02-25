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
        var newProduct = new Domain.Entities.Product()
        {
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            
        };
        var warehouseToAdd = await _warehouseRepository.AddProductToWarehouse(warehouseId, newProduct,quantity);

        return warehouseToAdd;
    }

    public async Task<int> AddNewWarehouseAsync(NewWarehouseDTO warehouse)
    {
        var newWarehouse = new Domain.Entities.Warehouse()
        {
            Name = warehouse.Name,
            Type = warehouse.Type
        };
        var data = await _warehouseRepository.AddNewWarehouse(newWarehouse);
       return data;
    }
}