using Application.Services.Client;
using Application.Services.Order;
using Application.Services.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions;

public static class ExtentionApplication
{
    public static void AddAplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IClientServices, ClientService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
    }
}