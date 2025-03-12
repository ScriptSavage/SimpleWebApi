using Domain.DTO;

namespace Application.Services.User;

public interface IUserService 
{
    Task<int> AddNewUserAsync(RegisterNewUserDTO registerNewUser);
    Task<string> GenerateJwtTokenAsync(LoginDTO userDto);
    
}