using System.Security.Cryptography;
using Domain.DTO;
using FluentValidation;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Domain.Validator;


public class RegisterUserDtoValidator : AbstractValidator<RegisterNewUserDTO>
{
    
    public RegisterUserDtoValidator(ProjectContext _context)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is required");
        
        RuleFor(x => x.Password)
            .MinimumLength(6)
            .NotEmpty();
    
        RuleFor(e => e.ConfirmedPassword)
            .Equal(e=>e.Password);
    
        RuleFor(e => e.Email)
            .Custom((value, context) =>
            {
           var isEmailInUse =  _context.Users.Any(e=>e.Email == value);
           if (isEmailInUse)
           {
               context.AddFailure("Email is already in use");
           }
            });
    }
}