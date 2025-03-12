using System.ComponentModel.DataAnnotations;

namespace Domain.DTO;

public class RegisterNewUserDTO
{
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string ConfirmedPassword { get; set; }
    
    public DateTime? BirthdayDate { get; set; }
    public int RoleId { get; set; } = 1;
}