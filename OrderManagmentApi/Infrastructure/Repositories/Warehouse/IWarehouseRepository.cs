using Domain.Entities;

namespace Infrastructure.Repositories.Warehouse;

public interface IWarehouseRepository
{
    Task<int> AddProductToWarehouse(int werehouseId , Product product , int quantity);
    Task<int> AddNewWarehouse(Domain.Entities.Warehouse warehouse);
}