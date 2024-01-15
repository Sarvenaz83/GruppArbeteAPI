using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty()
                .WithMessage("Author name cann't be empty.")
                .MaximumLength(50)
                .WithMessage("Author name must not exceed 50 characters.");
        }
    }
}
