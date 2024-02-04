using Application.Dtos.UserDtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.PurchaseBook
{
    public class PurchaseBookCommand : IRequest<PurchaseResultDto>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }

    }
}
