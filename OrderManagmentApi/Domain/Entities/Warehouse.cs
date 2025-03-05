using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Warehouse
{
    [Key]
    public int  Id { get; set; }

    public string Name { get; set; } = default!;

    public string Type { get; set; } = default!;

    public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; }

    public ICollection<Order> Orders { get; set; }
}