using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;



public class ProjectContext : DbContext
{

    public ProjectContext(DbContextOptions <ProjectContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public DbSet<Warehouse> Warehouse { get; set; }
    public DbSet<WarehouseProduct?> WarehouseProducts { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}