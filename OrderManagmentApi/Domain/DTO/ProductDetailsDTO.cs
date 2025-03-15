using Microsoft.EntityFrameworkCore;

namespace Domain.DTO;

public class ProductDetailsDTO
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    [Precision(20,2)]
    public Decimal Price { get; set; }
}