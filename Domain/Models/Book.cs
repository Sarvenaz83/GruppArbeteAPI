using System.Text.Json.Serialization;

namespace Domain.Models;

public partial class Book
{
    public Guid BookId { get; set; }

    public string? Title { get; set; }

    public Guid? AuthorId { get; set; }

    public string? Genre { get; set; }

    public DateTime? PubYear { get; set; }

    public int? Pages { get; set; }

    public decimal? Rating { get; set; }

    public string? Summary { get; set; }

    [JsonIgnore]
    public virtual Author? Author { get; set; }
    public bool IsDeleted { get; set; }

    public int Price { get; set; }
    public string ArticleNumber { get; set; }

}
