using Application.DTO;
using Application.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagmentApi.Controllers;

[ApiController]
[Route("api/products")]
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

    [HttpDelete]
    [Route("{productId}")]
    public async Task<IActionResult> DeleteProductAsync(int productId)
    {
        await _productService.DeleteProductAsync(productId);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}
