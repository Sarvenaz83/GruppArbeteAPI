using Application.Dtos.PurchaseHistoryDto;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
