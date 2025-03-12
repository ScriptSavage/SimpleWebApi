using Application.Services.Client;
using Application.Services.Order;
using Domain.DTO;
using Infrastructure.Repositories.Client;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientServices _clientServices;
    private readonly IOrderService _orderService;


    public ClientController(IClientServices clientServices, IOrderService orderService)
    {
        _clientServices = clientServices;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientsAsync()
    {
        var response = await _clientServices.GetClientsAsync();
        return Ok(response);
    }
    
    
    [HttpGet]
    [Route("{clientId}/order")]
    public async Task<IActionResult> GetClientOrdersAsync([FromRoute] int clientId)
    {
        var clientExists = await _clientServices.DoesClientExistAsync(clientId);
        if (!clientExists)
        {
            return StatusCode(StatusCodes.Status404NotFound, "Client does not exist");
        }

        var result = await _orderService.GetClientOrdersAsync(clientId);
        return Ok(result);
    }


    [HttpDelete]
    [Route("{clientId}")]
    public async Task<IActionResult> DeleteClientAsync([FromRoute] int clientId)
    {
        var doesClientExistAsync = await _clientServices.DoesClientExistAsync(clientId);
        if (!doesClientExistAsync)
        {
            return StatusCode(StatusCodes.Status404NotFound, "Client does not exist");
        }

        await _clientServices.DeleteClientAsync(clientId);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}