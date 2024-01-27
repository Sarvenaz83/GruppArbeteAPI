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

            RuleFor(purchaseHistory => purchaseHistory.TimeOfPurchase)
                .NotEmpty().WithMessage("TimeOfPurchase kan inte vara tom");

            RuleFor(purchaseHistory => purchaseHistory.TotalPrice)
                .NotEmpty().WithMessage("TotalPrice kan inte vara empty")
                .GreaterThan(0).WithMessage("TotalPrice måste vara mer än 0");

            RuleFor(purchaseHistory => purchaseHistory.User)
                .NotNull().WithMessage("User cannot be null");
        }
    }
}
