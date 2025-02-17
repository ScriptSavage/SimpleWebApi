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
        var newProduct = new Domain.Entites.Product()
        {
            Name = newProductDto.Name,
            Description = newProductDto.Description,
            Price = newProductDto.Price
        };
        
       var resultProduct = await _productRepository.AddNewProductAsync(newProduct);

       return resultProduct;
    }
}