namespace Infrastructure.Repositories.User;

public interface IUserRepository
{
    Task<int> AddAsync(Domain.Entities.User user);

    Task<bool> DoesUserExistAsync(string email);
    
    Task<Domain.Entities.User> FingByEmailAsync(string email);
}