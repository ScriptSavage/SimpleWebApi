using Application.DTO;

namespace Application.Services.Product;

public interface IProductService
{
    Task<int> AddNewProductAsync(NewProductDTO newProductDto);
    
    Task<int> DeleteProductAsync(int productId);
}