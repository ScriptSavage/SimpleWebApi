using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> DoesProductExistAsync(int id)
    {
        var product = await _context.Products.Where(e=>e.Id == id).AnyAsync();
        return product;
    }

    public async Task<int> DeleteProductAsync(int productId)
    {
       var data = await _context.Products.Where(e=>e.Id == productId).FirstOrDefaultAsync();
       if (data != null)
       {
           _context.Products.Remove(data);
       }

       var commitData = await _context.SaveChangesAsync();
       
       return commitData;
    }
}