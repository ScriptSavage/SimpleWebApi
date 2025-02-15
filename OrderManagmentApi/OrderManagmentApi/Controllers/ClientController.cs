using Application.Services.Client;
using Infrastructure.Repositories.Client;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("Clients")]
public class ClientController : ControllerBase
{
    private readonly IClientServices _clientServices;

    public ClientController(IClientServices clientServices)
    {
        _clientServices = clientServices;
    }


    [HttpGet]
    public async Task<IActionResult> GetClientsAsync()
    {
        var response = await _clientServices.GetClientsAsync();
        return Ok(response);
    }
}