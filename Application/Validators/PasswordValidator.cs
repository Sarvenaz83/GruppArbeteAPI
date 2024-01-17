using FluentValidation;

namespace Application.Validators
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password => password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number")
                .Matches(@"[\^$*.\[\]{}()?\-\!@#%&/\\,><':;|_~`]").WithMessage("Password must contain at least one special character");
        }
    }
}
