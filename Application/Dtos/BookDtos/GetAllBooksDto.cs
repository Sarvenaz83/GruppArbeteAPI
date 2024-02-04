namespace Application.Dtos.BookDtos
{
    public class GetAllBooksDto
    {
        public Guid BookId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? AuthorName { get; set; } = string.Empty;
        public string? Genre { get; set; } = string.Empty;
        public int? PubYear { get; set; }
        public int? Pages { get; set; }
        public int? Price { get; set; }
        public decimal? Rating { get; set; }
        public string? Summary { get; set; } = string.Empty;
    }
}
