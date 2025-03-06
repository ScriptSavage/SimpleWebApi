using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.DTO;

public class NewProductDTO
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(250)]
    public string Description { get; set; } = default!;

    [Precision(20,2)]
    public Decimal Price { get; set; }
}