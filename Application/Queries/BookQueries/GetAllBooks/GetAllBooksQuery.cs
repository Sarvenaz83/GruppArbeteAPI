using Application.Dtos.BookDtos;
using MediatR;

namespace Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<GetAllBooksDto>>
    {

    }
}
