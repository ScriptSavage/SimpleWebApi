using Application.Services.Client;
using Application.Services.Order;
using Application.Services.Product;
using Application.Services.Warehouse;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions;

public static class ExtentionApplication
{
    public static void AddAplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IClientServices, ClientService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IWarehouseService, WarehouseService>();
    }
}