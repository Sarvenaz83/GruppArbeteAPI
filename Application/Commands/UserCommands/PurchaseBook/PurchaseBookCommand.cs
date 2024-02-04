using Application.Dtos.UserDtos;
using MediatR;

namespace Application.Commands.UserCommands.PurchaseBook
{
    public class PurchaseBookCommand : IRequest<PurchaseResultDto>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }

    }
}
