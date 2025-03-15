using Domain.DTO;

namespace Application.Services.Interfaces;

public interface IProductService
{
    Task<int> AddNewProductAsync(NewProductDTO newProductDto);
    
    Task<int> DeleteProductAsync(int productId);
    
    Task<int> UpdateProductAsync(NewProductDTO productDto , int productId);
    Task<int>DeleteProductFromWarehouseAsync(int warehouseId , int productId);
    
    Task<ProductDetailsDTO> GetProductDetailsAsync(int productId);
}