using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Client;
using Infrastructure.Repositories.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions;

public  static class ExtentionInfrastructure
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
            
        services.AddDbContext<ProjectContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

    }
}