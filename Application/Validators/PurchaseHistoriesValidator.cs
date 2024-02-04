using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class PurchaseHistoryValidator : AbstractValidator<PurchaseHistory>
    {
        public PurchaseHistoryValidator()
        {
            RuleFor(purchaseHistory => purchaseHistory.PurchaseHistoryId)
                .NotEmpty().WithMessage("PurchaseId kan inte vara tom");

            RuleFor(purchaseHistory => purchaseHistory.UserId)
                .NotEmpty().WithMessage("UserId kan inte vara tom");

            RuleFor(purchaseHistory => purchaseHistory.User)
                .NotNull().WithMessage("User cannot be null");
        }
    }
}
