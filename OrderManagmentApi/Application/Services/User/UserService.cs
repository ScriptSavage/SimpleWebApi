using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Exceptions;
using Domain.DTO;
using Infrastructure;
using Infrastructure.Repositories.Client;
using Infrastructure.Repositories.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public UserService(IUserRepository userRepository, IClientRepository clientRepository, IPasswordHasher<Domain.Entities.User> passwordHasher, AuthenticationSettings authenticationSettings)
    {
        _userRepository = userRepository;
        _clientRepository = clientRepository;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
    }

    public async Task<int> AddNewUserAsync(RegisterNewUserDTO registerNewUser)
    {
        var newUser = new Domain.Entities.User()
        {
            FirstName = registerNewUser.FirstName,
            LastName = registerNewUser.LastName,
            Email = registerNewUser.Email,
            BirthdayDate = registerNewUser.BirthdayDate,
            RoleID = registerNewUser.RoleId
        };

        var newClient = new Domain.Entities.Client()
        {
            Id = newUser.UserId,
            FirstName = registerNewUser.FirstName,
            LastName = registerNewUser.LastName,
        };
      
        
       var hashedPassword =  _passwordHasher.HashPassword(newUser, registerNewUser.Password);
       newUser.PasswordHash = hashedPassword;
       await _clientRepository.AddNewClientAsync(newClient);
        return await _userRepository.AddAsync(newUser);
    }

    public async Task<string> GenerateJwtTokenAsync(LoginDTO userDto)
    {
        var doesUserExists = await _userRepository.DoesUserExistAsync(userDto.Email);
        if (!doesUserExists)
        {
            throw new NotFoundException("Use NOT Found");
        }
        var user = await _userRepository.FingByEmailAsync(userDto.Email);
        
        var isGivenPasswordCorrect = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash,userDto.Password);

        if (isGivenPasswordCorrect == PasswordVerificationResult.Failed) 
        {
            throw new BadRequestException("Invalid UserName ora Password");
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
            new Claim(ClaimTypes.Name,$"{user.FirstName}  {user.FirstName}"),
            new Claim(ClaimTypes.Role,user.Role.RoleName),
            new Claim(ClaimTypes.DateOfBirth,user.BirthdayDate.Value.ToString("yyyy-MM-dd"))
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expire = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires:expire,
            signingCredentials: creds);
        
        
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
        
    }
}