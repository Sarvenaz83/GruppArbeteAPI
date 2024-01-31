using Application.Dtos.BookDtos;
using MediatR;

namespace Application.Queries.BookQueries.GetBooksByRating
{
    public class GetBooksByRatingQuery : IRequest<List<GetBooksByRatingDto>>
    {
        public decimal MinimumRating { get; set; }
        public GetBooksByRatingQuery(decimal minimumRating)
        {
            MinimumRating = minimumRating;
        }
    }
}
