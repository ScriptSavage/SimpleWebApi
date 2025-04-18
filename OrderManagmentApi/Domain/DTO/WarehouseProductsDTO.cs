namespace Domain.DTO;

public class WarehouseProductsDto
{
    public string Name { get; set; } = default!;
    public List<ProductsDTO> Products { get; set; }
}

public class ProductsDTO
{
    public string Name { get; set; } = default!;
    public Decimal Price { get; set; }
    public int  Stock { get; set; }
}