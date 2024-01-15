using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Author
{
    public Guid AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
