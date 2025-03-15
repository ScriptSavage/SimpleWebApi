using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions;

public static class ExtentionApplication
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IClientServices, ClientService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IWarehouseService, WarehouseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    }
}