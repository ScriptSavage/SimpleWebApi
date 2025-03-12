using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    public string RoleName { get; set; }
}