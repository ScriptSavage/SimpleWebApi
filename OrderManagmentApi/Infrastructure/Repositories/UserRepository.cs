using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ProjectContext _context;

    public UserRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<int> AddUserAsync(Domain.Entities.User user)
    {
        _context.Users.Add(user);
       var commitData = await _context.SaveChangesAsync();
       return commitData;
    }

    public async Task<bool> DoesUserExistAsync(string email)
    {
        var user = await _context
            .Users
            .AnyAsync(e=>e.Email == email);
        return user;
    }

    public async Task<Domain.Entities.User> FingByEmailAsync(string email)
    {
        var user = await _context
            .Users
            .Include(e=>e.Role)
            .FirstOrDefaultAsync(e=>e.Email == email);
       return user;
    }
}