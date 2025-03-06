namespace Domain.DTO;

public class ClientOrdersDTO
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public List<OrderDTO> OrderDtos { get; set; }
}

public class OrderDTO
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Decimal TotalPrice { get; set; }

    public List<ProductDTO> ProductDtos { get; set; }
}


public class ProductDTO
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    
    public int Amount { get; set; }

}