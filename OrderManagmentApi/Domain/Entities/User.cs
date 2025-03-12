using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? BirthdayDate { get; set; }

    public string PasswordHash { get; set; }

    public int RoleID { get; set; }
    [ForeignKey(nameof(RoleID))]
    public Role Role { get; set; }
}