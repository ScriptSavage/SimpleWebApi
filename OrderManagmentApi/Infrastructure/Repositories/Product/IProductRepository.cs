using Domain.Entites;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task<int> AddNewProductAsync(Product product);
}