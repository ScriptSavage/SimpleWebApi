using Application.Services.Interfaces;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CreateNewOrder(CreateNewOrderDTO createNewOrderDTO)
    {
        var result = await _orderService.AddNewOrder(createNewOrderDTO);
        return StatusCode(StatusCodes.Status201Created, result);
    }

}