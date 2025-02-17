using Application.DTO;
using Application.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewProductAsync([FromBody] NewProductDTO productDto)
    {
        await _productService.AddNewProductAsync(productDto);
        return StatusCode(StatusCodes.Status201Created,productDto);
    }
}