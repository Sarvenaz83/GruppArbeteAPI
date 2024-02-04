namespace Application.Dtos.BookDtos
{
    public class GetBookByTitleDto
    {

        public string? Title { get; set; }
        public string? AuthorName { get; set; }

        public string? Genre { get; set; }

        public int? PubYear { get; set; }

        public int? Pages { get; set; }
        public int? Price { get; set; }

        public decimal? Rating { get; set; }

        public string? Summary { get; set; }

    }
}
