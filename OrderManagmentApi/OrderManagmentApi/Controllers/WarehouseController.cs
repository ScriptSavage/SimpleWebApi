using Application.DTO;
using Application.Services.Warehouse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("api/warehouses")]
public class WarehouseController :ControllerBase
{ 
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpPost]
    [Route("{warehouseId}/products")]
    public async Task<IActionResult> AddNewProductToWarehouseAsync(int warehouseId, [FromBody] NewProductDTO product,int quantity)
    {
        var data = await _warehouseService.AddNewProductToWarehouse(warehouseId, product,quantity);
        return StatusCode(StatusCodes.Status201Created, data);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewWarehouseAsync([FromBody] NewWarehouseDTO product)
    {
        var data = await _warehouseService.AddNewWarehouseAsync(product);
        return StatusCode(StatusCodes.Status201Created, data);
    }
}
