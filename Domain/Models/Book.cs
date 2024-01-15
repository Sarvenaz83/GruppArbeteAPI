using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Book
{
    public Guid BookId { get; set; }

    public string? Title { get; set; }

    public Guid? AuthorId { get; set; }

    public string? Genre { get; set; }

    public DateTime? PubYear { get; set; }

    public int? Pages { get; set; }

    public int? StockBalance { get; set; }

    public decimal? Rating { get; set; }

    public string? Summary { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
