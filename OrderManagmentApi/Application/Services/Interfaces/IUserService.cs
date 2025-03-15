using Domain.DTO;

namespace Application.Services.Interfaces;

public interface IUserService 
{
    Task<int> AddNewUserAsync(RegisterNewUserDTO registerNewUser);
    Task<string> GenerateJwtTokenAsync(LoginDTO userDto);
    
}