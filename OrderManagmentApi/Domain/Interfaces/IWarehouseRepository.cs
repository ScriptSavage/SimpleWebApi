using Domain.Entities;

namespace Domain.Interfaces;

public interface IWarehouseRepository
{
    Task<int> AddProductToWarehouse(int werehouseId, Product product, int quantity);
    Task<int> AddNewWarehouse(Domain.Entities.Warehouse warehouse);

    Task<List<Domain.Entities.Warehouse>> GetWarehousesProducts();
    
    Task<Domain.Entities.Warehouse> GetWarehouseById(int id);
    Task<WarehouseProduct?> GetWarehouseProductAsync(int warehouseId, int productId);
}
