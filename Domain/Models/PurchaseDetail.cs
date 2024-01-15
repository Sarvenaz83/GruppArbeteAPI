namespace Domain.Models;

public partial class PurchaseDetail
{
    public Guid PurchaseDetailId { get; set; }

    public Guid? PurchaseId { get; set; }

    public Guid? BookId { get; set; }

    public int? Quantity { get; set; }

    public int? PricePerUnit { get; set; }

    public DateTime? DateDetail { get; set; }

    public virtual Book? Book { get; set; }

    public virtual PurchaseHistory? Purchase { get; set; }
}
