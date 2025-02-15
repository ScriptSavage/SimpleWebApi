using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;



public class ProjectContext : DbContext
{

    public ProjectContext(DbContextOptions <ProjectContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}