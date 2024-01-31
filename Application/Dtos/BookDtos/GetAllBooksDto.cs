namespace Application.Dtos.BookDtos
{
    public class GetAllBooksDto
    {
        public string Title { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime? PubYear { get; set; }
        public int? Pages { get; set; }
        public int? StockBalance { get; set; }
        public decimal? Rating { get; set; }
        public string Summary { get; set; } = string.Empty;
    }
}
