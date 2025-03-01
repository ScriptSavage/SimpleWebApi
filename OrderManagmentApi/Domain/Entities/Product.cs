using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    [Precision(20,2)]
    public Decimal Price { get; set; }

    

    public IEnumerable<OrderProduct>? OrderProducts { get; set; }
    
    public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; }

}