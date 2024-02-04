using Application.Dtos.WalletDtos;
using Infrastructure.Repository.UserRepository;
using Infrastructure.Repository.WalletRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.WalletCommands
{
    public class UpdateWalletByIdCommandHandler : IRequestHandler<UpdateWalletByIdCommand, WalletDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository; // Antag att detta existerar

        public UpdateWalletByIdCommandHandler(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }

        public async Task<WalletDto> Handle(UpdateWalletByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var wallet = await _walletRepository.UpdateBalance(request.UserId, request.Wallet.Balance);


            return new WalletDto
            {
                Balance = request.Wallet.Balance
            };
        }
    }
}
