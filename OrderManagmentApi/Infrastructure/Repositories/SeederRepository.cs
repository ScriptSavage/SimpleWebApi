using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class SeederRepository
{
    private readonly ProjectContext _context;

    public SeederRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task SeedData()
    {
        if (_context.Database.CanConnect())
        {
            if (!_context.Roles.Any())
            {
                var roles = GetRoles();
                _context.Roles.AddRange(roles);
                await _context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>();
        
        var user = new Role
        {
            RoleName = "User"
        };

        var admin = new Role
        {
            RoleName = "Admin"
        };
        roles.Add(admin);
        roles.Add(user);
        
        return roles;

    }
}