using Application.Dtos.WalletDtos;
using MediatR;

namespace Application.Commands.WalletCommands
{
    public class UpdateWalletByIdCommand : IRequest<WalletDto>
    {
        public Guid UserId { get; set; }
        public WalletDto Wallet { get; set; }

        public UpdateWalletByIdCommand(Guid userId, WalletDto wallet)
        {

            UserId = userId;
            Wallet = wallet;
        }
    }
}
