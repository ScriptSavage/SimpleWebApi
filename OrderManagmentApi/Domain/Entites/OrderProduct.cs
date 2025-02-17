using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entites;

[PrimaryKey(nameof(ProductId),nameof(OrderId))]
public class OrderProduct
{
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }

    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }

    public int Amount { get; set; }
}