using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class Client
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public IEnumerable<Order> Orders { get; set; }
}