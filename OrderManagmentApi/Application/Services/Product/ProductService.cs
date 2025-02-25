using Application.DTO;
using Infrastructure.Repositories;

namespace Application.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> AddNewProductAsync(NewProductDTO newProductDto)
    {
        var newProduct = new Domain.Entities.Product()
        {
            Name = newProductDto.Name,
            Description = newProductDto.Description,
            Price = newProductDto.Price
        };
        
       var resultProduct = await _productRepository.AddNewProductAsync(newProduct);

       return resultProduct;
    }

    public async Task<int> DeleteProductAsync(int productId)
    {
        var doesProductExist = await _productRepository.DoesProductExistAsync(productId);
        if (!doesProductExist)
        {
            throw new Exception($"Product with id: {productId} does not exist");
        }
        var resultProduct = await _productRepository.DeleteProductAsync(productId);

        return resultProduct;
    }

    public async Task<int> UpdateProductAsync(NewProductDTO productDto,int productId)
    {
        var dataToUpdate = await _productRepository.UpdateProductDescriptionAsync(productDto.Description,productId);
        return dataToUpdate;
    }

    public async Task<int> DeleteProductFromWarehouseAsync(int warehouseId, int productId)
    {
        var resultProduct = await _productRepository.DeleteProductFromWarehouseAsync(warehouseId, productId);
        return resultProduct;
    }
}