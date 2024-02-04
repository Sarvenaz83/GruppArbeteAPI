namespace Application.Dtos.BookDtos
{
    public class BookByIdDto
    {
        public string? BookTitle { get; set; }
        public string? AuthorName { get; set; }
        public string? Genre { get; set; }
        public DateTime? PubYear { get; set; }
        public int? Pages { get; set; }
        public decimal? Rating { get; set; }
        public string? Summary { get; set; }
    }
}
