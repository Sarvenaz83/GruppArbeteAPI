using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.WalletCommands
{
    public class UpdateWalletByIdCommand : IRequest<WalletDto>
    {
        public WalletDto Wallet { get; set; }

        public UpdateWalletByIdCommand(WalletDto wallet)
        {
            Wallet = wallet;
        }
    }
}
