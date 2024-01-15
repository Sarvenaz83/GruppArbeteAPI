namespace Domain.Models;

public partial class AuthorModel
{
    public Guid AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
