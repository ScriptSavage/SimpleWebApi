using Domain.Entities;

namespace Infrastructure.Repositories.Warehouse;

public interface IWarehouseRepository
{
    Task<int> AddWarehouseProdcutAsync(int werehouseId , Product product , int quantity);
}