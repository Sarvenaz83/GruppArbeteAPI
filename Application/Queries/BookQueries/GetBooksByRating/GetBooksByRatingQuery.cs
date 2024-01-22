using Domain.Models;
using MediatR;

namespace Application.Queries.BookQueries.GetBooksByRating
{
    public class GetBooksByRatingQuery : IRequest<List<Book>>
    {
        public decimal MinimumRating { get; set; }
        public GetBooksByRatingQuery(decimal minimumRating)
        {
            MinimumRating = minimumRating;
        }
    }
}
