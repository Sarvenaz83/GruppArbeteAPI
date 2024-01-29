namespace Domain.Models;

public partial class Receipt
{
    public Guid ReceiptId { get; set; }

    public Guid? PurchaseHistoryId { get; set; }

    public Guid? BookId { get; set; }

    public int? Quantity { get; set; }

    public int? PricePerUnit { get; set; }

    public DateTime? DateDetail { get; set; }

    public virtual Book? Book { get; set; }

    public virtual PurchaseHistory? PurchaseHistories { get; set; }
}
