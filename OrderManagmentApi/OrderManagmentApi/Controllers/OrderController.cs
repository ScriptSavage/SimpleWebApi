using Application.DTO;
using Application.Services.Order;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateNewOrder(CreateNewOrderDTO createNewOrderDTO)
    {
        var result = await _orderService.AddNewOrder(createNewOrderDTO);
        return StatusCode(StatusCodes.Status201Created, result);
    }

}