using Application.Dtos.WalletDtos;
using FluentValidation;

namespace Application.Validators
{
    public class WalletValidator : AbstractValidator<WalletDto>
    {
        public WalletValidator()
        {
            RuleFor(wallet => wallet.Balance)
                            .GreaterThanOrEqualTo(0).WithMessage("Balance cannot be negative.")
                            .Must(b => b == (int)b).WithMessage("Balance must be a whole number.");
        }
    }
}
