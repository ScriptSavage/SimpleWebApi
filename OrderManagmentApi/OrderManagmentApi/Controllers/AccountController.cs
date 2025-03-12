using Application.Services.User;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("ap/account")]
public class AccountController : ControllerBase
{ 
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterNewUser([FromBody] RegisterNewUserDTO registerNewUserDTO)
    {
        var res = await _userService.AddNewUserAsync(registerNewUserDTO);
        return Ok(res);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
    {
        var token  = await _userService.GenerateJwtTokenAsync(loginDTO);
        return Ok(token);
        
    }
}