using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // Validering för UserName
            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("Username cannot be empty")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters");

            // Validering för Password
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number")
                .Matches(@"[\^$*.\[\]{}()?\-\!@#%&/\\,><':;|_~`]").WithMessage("Password must contain at least one special character");

            // Validering för Email
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email format");

            // Validering för TelephoneNumber
            RuleFor(user => user.TelephoneNumber)
                .NotEmpty().WithMessage("Telephone number cannot be empty")
                .Matches(@"^\+\d{10,15}$").WithMessage("Telephone number must be in international format and contain 10-15 digits");

            // Validering för FirstName
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty");

            // Validering för SurName
            RuleFor(user => user.SurName)
                .NotEmpty().WithMessage("Surname cannot be empty");

        }
    }
}
