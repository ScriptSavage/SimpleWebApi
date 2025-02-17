using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entites;

public class Order
{
    public int  OrderId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Precision(20,2)]
    public Decimal TotalPrice { get; set; }
    public int ClientID { get; set; }
    [ForeignKey(nameof(ClientID))]
    public Client Client { get; set; }
    
    
    public IEnumerable<OrderProduct>? OrderProducts { get; set; }

}