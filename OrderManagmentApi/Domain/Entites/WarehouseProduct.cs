using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entites;

[PrimaryKey(nameof(ProductId), nameof(WarehouseId))]
public class WarehouseProduct
{
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product product { get; set; }
    
    public int WarehouseId { get; set; }
    [ForeignKey(nameof(WarehouseId))]
    public Warehouse Warehouse { get; set; }

    public int  Stock { get; set; }
    
    public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; }
}