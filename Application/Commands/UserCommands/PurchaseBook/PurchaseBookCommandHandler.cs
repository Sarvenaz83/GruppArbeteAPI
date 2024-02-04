using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Infrastructure.Repository.PurchaseHistoriesRepository;
using Infrastructure.Repository.ReceiptRepository;
using Infrastructure.Repository.WalletRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos.UserDtos;

namespace Application.Commands.UserCommands.PurchaseBook
{
    public class PurchaseBookCommandHandler : IRequestHandler<PurchaseBookCommand, PurchaseResultDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IPurchaseHistoriesRepository _purchaseHistoriesRepository;
        private readonly IReceiptRepository _receiptRepository;

        public PurchaseBookCommandHandler(
            IBookRepository bookRepository,
            IWalletRepository walletRepository,
            IPurchaseHistoriesRepository purchaseHistoriesRepository,
            IReceiptRepository receiptRepository)
        {
            _bookRepository = bookRepository;
            _walletRepository = walletRepository;
            _purchaseHistoriesRepository = purchaseHistoriesRepository;
            _receiptRepository = receiptRepository;
        }

        public async Task<PurchaseResultDto> Handle(PurchaseBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.BookId);
            if (book == null)
            {
                return new PurchaseResultDto { Success = false, Message = "Book not available." };
            }

            var wallet = await _walletRepository.GetWalletByUserIdAsync(request.UserId);
            if (wallet == null)
            {
                return new PurchaseResultDto { Success = false, Message = "Wallet not found." };
            }

            int totalCost = book.Price; // Assume Price is for a single book
            if (wallet.Balance < totalCost)
            {
                return new PurchaseResultDto { Success = false, Message = "Insufficient balance." };
            }

            await _walletRepository.UpdateBalance(request.UserId, wallet.Balance - totalCost);

            // Skapa ett kvitto
            var receipt = new Receipt
            {
                ReceiptId = Guid.NewGuid(),
                BookId = book.BookId,
                Quantity = 1, // Because we're only buying one book
                TotalPrice = totalCost,
                DateDetail = DateTime.UtcNow
            };
            await _receiptRepository.CreateReceiptAsync(receipt);

            // Hämta befintlig PurchaseHistory eller skapa en ny om det inte finns någon
            var purchaseHistory = await _purchaseHistoriesRepository.GetPurchaseHistoryByUserIdAsync(request.UserId);
            if (purchaseHistory == null)
            {
                purchaseHistory = new PurchaseHistory
                {
                    PurchaseHistoryId = Guid.NewGuid(),
                    UserId = request.UserId,
                };
                await _purchaseHistoriesRepository.CreatePurchaseHistoryAsync(purchaseHistory);
            }

            // Lägg till Receipt i PurchaseHistory
            purchaseHistory.Receipts.Add(receipt);
            await _purchaseHistoriesRepository.UpdatePurchaseHistoryAsync(purchaseHistory);

            // Soft deletes book
            book.IsDeleted = true;
            await _bookRepository.UpdateBookByIdAsync(book);

            // Ta bort UserId från svaret
            return new PurchaseResultDto { Success = true, Message = "Purchase successful" };
        }
    }
}
