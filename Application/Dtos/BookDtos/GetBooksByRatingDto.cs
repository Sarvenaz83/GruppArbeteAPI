namespace Application.Dtos.BookDtos
{
    public class GetBooksByRatingDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}
