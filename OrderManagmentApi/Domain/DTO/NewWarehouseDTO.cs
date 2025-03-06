using System.ComponentModel.DataAnnotations;

namespace Domain.DTO;

public class NewWarehouseDTO
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [MaxLength(50)]
    public string Type { get; set; } = default!;
}