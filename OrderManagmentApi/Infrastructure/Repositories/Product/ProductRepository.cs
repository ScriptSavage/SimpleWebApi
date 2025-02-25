using Application.Exceptions;
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

    public async Task<int> UpdateProductDescriptionAsync(string description,int productId)
    {
        var productToUpdate = await _context.Products.Where(e=>e.Id == productId).FirstOrDefaultAsync();
        if (productToUpdate == null)
        {
            throw new NotFoundException("Product not found");
        }

        productToUpdate.Description = description;
       var commit = await _context.SaveChangesAsync();


       return commit;
    }

    public async Task<int> DeleteProductFromWarehouseAsync(int productId, int warehouseId)
    {
        int result = 0;
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var warehouseProduct = await _context.WarehouseProducts
                    .FirstOrDefaultAsync(wp => wp.ProductId == productId && wp.WarehouseId == warehouseId);
            
                if (warehouseProduct == null)
                {
                    throw new NotFoundException("Produkt is not assignt to Warehouse");
                }
            
                _context.WarehouseProducts.Remove(warehouseProduct);
            
                var isProductUsedElsewhere = await _context.WarehouseProducts
                    .AnyAsync(wp => wp.ProductId == productId && wp.WarehouseId != warehouseId);
            
                if (!isProductUsedElsewhere)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                    if (product != null)
                    {
                        _context.Products.Remove(product);
                    }
                }
            
                result = await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Something went wrong", ex);
            }
        }
        return result;
    }

}