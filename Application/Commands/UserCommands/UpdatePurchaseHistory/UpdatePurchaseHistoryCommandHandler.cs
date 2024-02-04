using Application.Commands.UserCommands.UpdatePurchaseHistory;
using Application.Dtos.PurchaseHistoryDto;
using Domain.Models;
using Infrastructure.Repository.PurchaseHistoriesRepository;
using MediatR;

namespace Application.Handlers.UserCommands
{
    public class UpdatePurchaseHistoryCommandHandler : IRequestHandler<UpdatePurchaseHistoryCommand, UpdatePurchaseHistoryDto>
    {
        private readonly IPurchaseHistoriesRepository _purchaseHistoriesRepository;

        public UpdatePurchaseHistoryCommandHandler(IPurchaseHistoriesRepository purchaseHistoriesRepository)
        {
            _purchaseHistoriesRepository = purchaseHistoriesRepository;
        }

        public async Task<UpdatePurchaseHistoryDto> Handle(UpdatePurchaseHistoryCommand request, CancellationToken cancellationToken)
        {
            var existingPurchaseHistory = await _purchaseHistoriesRepository.GetPurchaseHistoryByUserIdAsync(request.UpdatePurchaseHistoryDto.UserId);

            if (existingPurchaseHistory == null)
            {
                // Hantera fallet där PurchaseHistory inte hittas
                return null; // eller kasta ett undantag
            }

            // Lägg till de nya kvitto-ID:erna i den befintliga inköpshistoriken
            foreach (var receiptId in request.UpdatePurchaseHistoryDto.NewReceiptIds)
            {
                existingPurchaseHistory.Receipts.Add(new Receipt { ReceiptId = receiptId });
            }

            // Uppdatera PurchaseHistory
            await _purchaseHistoriesRepository.UpdatePurchaseHistoryAsync(existingPurchaseHistory);

            // Konvertera den uppdaterade PurchaseHistory till UpdatePurchaseHistoryDto
            return new UpdatePurchaseHistoryDto
            {
                UserId = request.UpdatePurchaseHistoryDto.UserId,
                NewReceiptIds = existingPurchaseHistory.Receipts.Select(r => r.ReceiptId).ToList()
            };
        }
    }
}
