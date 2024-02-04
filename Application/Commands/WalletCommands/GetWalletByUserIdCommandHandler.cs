using Domain.Models;
using Infrastructure.Repository.WalletRepository;
using MediatR;

namespace Application.Commands.WalletCommands
{
    public class GetWalletByUserIdCommandHandler : IRequestHandler<GetWalletByUserIdCommand, Wallet>
    {
        private readonly IWalletRepository _walletRepository;

        public GetWalletByUserIdCommandHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Wallet> Handle(GetWalletByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetWalletByUserIdAsync(request.UserId);
        }
    }
}