using Domain.Models;
using MediatR;

namespace Application.Commands.WalletCommands
{
    public class GetWalletByUserIdCommand : IRequest<Wallet>
    {
        public Guid UserId { get; }

        public GetWalletByUserIdCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
