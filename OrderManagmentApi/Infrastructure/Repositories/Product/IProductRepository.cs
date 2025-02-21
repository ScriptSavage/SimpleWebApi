using Domain.Entites;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task<int> AddNewProductAsync(Product product);
    
    Task<bool> DoesProductExistAsync(int id);
    
    Task<int> DeleteProductAsync(int productId);
}