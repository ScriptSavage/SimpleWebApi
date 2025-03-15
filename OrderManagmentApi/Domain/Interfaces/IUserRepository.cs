namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<int> AddUserAsync(Domain.Entities.User user);

    Task<bool> DoesUserExistAsync(string email);
    
    Task<Domain.Entities.User> FingByEmailAsync(string email);
}