using Application.Services.Product;
using Domain.DTO;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Warehouse;

namespace Application.Services.Warehouse;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IProductRepository _productRepository;
    public WarehouseService(IWarehouseRepository warehouseRepository, IProductRepository productRepository)
    {
        _warehouseRepository = warehouseRepository;
        _productRepository = productRepository;
    }

    public async Task<int> AddNewProductToWarehouse(int warehouseId, NewProductDTO product ,int quantity)
    {
        var newProduct = new Domain.Entities.Product()
        {
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            
        };
        var warehouseToAdd = await _warehouseRepository.AddProductToWarehouse(warehouseId, newProduct,quantity);

        return warehouseToAdd;
    }

    public async Task<int> AddNewWarehouseAsync(NewWarehouseDTO warehouse)
    {
        var newWarehouse = new Domain.Entities.Warehouse()
        {
            Name = warehouse.Name,
            Type = warehouse.Type
        };
        var data = await _warehouseRepository.AddNewWarehouse(newWarehouse);
       return data;
    }

    public async Task<List<WarehouseProductsDto>> GetWarehouseProductsAsync()
    {
        var warehouseProducts = await _warehouseRepository.GetWarehousesProducts();

        var data = warehouseProducts
            .Select(e => new WarehouseProductsDto()
            {
                Name = e.Name,
               Products = e.WarehouseProducts.Select(p => new ProductsDTO()
               {
                   Name = p.product.Name,
                   Price = p.product.Price,
                   Stock = p.Stock
               }).ToList()
            }).ToList();
        
            return data;
    }

    public async Task<WerehouseProductSalesDTO> GetWarehouseProductsSalesAsync(int warehouseId)
    {
        var warehouse = await _warehouseRepository.GetWarehouseById(warehouseId);
        var orders = await _productRepository.GetAllOrdersByWarehouseAsync(warehouseId);
        
       
        var productSales = orders
            .SelectMany(o => o.OrderProducts)      
            .GroupBy(op => op.ProductId)           
            .Select(g => new ProductSalesDTO
            {
                ProductName = g.First().Product.Name,
                Quantity = g.Sum(x => x.Amount)
            })
            .ToList();
        var result = new WerehouseProductSalesDTO
        {
            WarehouseName = warehouse.Name,
            ProductSales = productSales
        };

        return result;    
        
    }
}