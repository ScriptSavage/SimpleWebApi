using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task<int> AddNewProductAsync(Product product);
    
    Task<bool> DoesProductExistAsync(int id);
    
    Task<int> DeleteProductAsync(int productId);
    
    Task<int> UpdateProductDescriptionAsync(string description,int id);
    
    Task<int>DeleteProductFromWarehouseAsync(int productId , int warehouseId);
    
    Task<List<Product>> GetAllProductsConnectedWithWarehouseAsync(int warehouseId);

    Task<List<Domain.Entities.Order>> GetAllOrdersByWarehouseAsync(int warehouseId);
}