using Domain.Entites;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProjectContext _context;

    public ProductRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<int> AddNewProductAsync(Product product)
    {
        var newProduct = await _context.Products.AddAsync(product);
       var commitData =  await _context.SaveChangesAsync();

       return commitData;
    }
}