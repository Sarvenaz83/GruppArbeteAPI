using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
