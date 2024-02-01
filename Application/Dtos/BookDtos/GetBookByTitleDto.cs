namespace Application.Dtos.BookDtos
{
    public class GetBookByTitleDto
    {

        public string? Title { get; set; }

        public string? Genre { get; set; }

        public DateTime? PubYear { get; set; }

        public int? Pages { get; set; }

        public int? StockBalance { get; set; }

        public decimal? Rating { get; set; }

        public string? Summary { get; set; }

        public bool IsDeleted { get; set; }

    }
}
