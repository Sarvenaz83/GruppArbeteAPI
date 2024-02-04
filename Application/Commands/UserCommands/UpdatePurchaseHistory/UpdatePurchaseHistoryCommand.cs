using Application.Dtos.PurchaseHistoryDto;
using MediatR;

namespace Application.Commands.UserCommands.UpdatePurchaseHistory
{
    public class UpdatePurchaseHistoryCommand : IRequest<UpdatePurchaseHistoryDto>
    {
        public UpdatePurchaseHistoryDto UpdatePurchaseHistoryDto { get; }

        public UpdatePurchaseHistoryCommand(UpdatePurchaseHistoryDto updatePurchaseHistoryDto)
        {
            UpdatePurchaseHistoryDto = updatePurchaseHistoryDto;
        }
    }
}
