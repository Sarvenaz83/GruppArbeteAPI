using FluentValidation;

namespace Application.Validators
{
    public class UsernameValidator : AbstractValidator<string>
    {
        public UsernameValidator()
        {
            RuleFor(username => username)
                .NotEmpty().WithMessage("Username cannot be empty")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters");
        }
    }
}
