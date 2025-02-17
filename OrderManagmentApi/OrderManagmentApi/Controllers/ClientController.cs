using Application.DTO;
using Application.Services.Client;
using Infrastructure.Repositories.Client;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("clients")]
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

    [HttpPost]
    public async Task<IActionResult> AddNewClientAsync([FromBody]ClientDTO clientDto)
    {
        var data = await _clientServices.AddNewClientDtoAsync(clientDto);
        
        return StatusCode(StatusCodes.Status201Created, data);
    }
}