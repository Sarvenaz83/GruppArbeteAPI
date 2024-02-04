using System.Text.Json.Serialization;

namespace Domain.Models;

public partial class Author
{
    public Guid AuthorId { get; set; }

    public string? AuthorName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public bool IsDeleted { get; set; }
}
