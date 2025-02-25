using Application.DTO;

namespace Application.Services.Warehouse;

public interface IWarehouseService
{
    Task<int> AddNewProductToWarehouse(int warehouseId, NewProductDTO product,int quantity);
    Task<int> AddNewWarehouseAsync(NewWarehouseDTO warehouse);
}