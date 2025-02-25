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

    [HttpPut]
    [Route("{productId}")]
    public async Task<IActionResult> UpdateProductAsync([FromBody]NewProductDTO productDto,int productId)
    {
        var dataToUpdate = await _productService.UpdateProductAsync(productDto,productId);
        return StatusCode(StatusCodes.Status201Created,dataToUpdate);
    }

    [HttpDelete]
    [Route("{productId}/{warehouseId}")]
    public async Task<IActionResult> DeleteProductFromWarehouseAsync(int productId, int warehouseId)
    {
         await _productService.DeleteProductFromWarehouseAsync(productId,warehouseId);
        return StatusCode(StatusCodes.Status204NoContent);

    }
}
