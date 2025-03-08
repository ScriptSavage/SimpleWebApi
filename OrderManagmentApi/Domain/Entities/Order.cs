using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Order
{
    [Key]
    public int  OrderId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Precision(20,2)]
    public Decimal TotalPrice { get; set; }
    public int ClientID { get; set; }
    [ForeignKey(nameof(ClientID))]
    public Client Client { get; set; }
    
    
    public ICollection<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();


    public int? WarehouseId { get; set; }
    [ForeignKey(nameof(WarehouseId))]
    public Warehouse? Warehouse { get; set; }

    
}