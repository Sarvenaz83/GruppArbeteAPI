using Domain.Models;
using MediatR;

namespace Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {

    }
}
