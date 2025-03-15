using Domain.DTO;

namespace Application.Services.Interfaces;

public interface IWarehouseService
{
    Task<int> AddNewProductToWarehouse(int warehouseId, NewProductDTO product,int quantity);
    Task<int> AddNewWarehouseAsync(NewWarehouseDTO warehouse);
    Task<List<WarehouseProductsDto>> GetWarehouseProductsAsync();
    Task<WerehouseProductSalesDTO> GetWarehouseProductsSalesAsync(int warehouseId);
}