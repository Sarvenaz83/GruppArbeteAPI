using Application.Dtos.AuthorDtos;
using FluentValidation;

namespace Application.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Author name is required.")
                .NotNull().WithMessage("Author name can not be null")
                .MaximumLength(100).WithMessage("Author name must not exceed 100 characters.");
        }
    }
}
