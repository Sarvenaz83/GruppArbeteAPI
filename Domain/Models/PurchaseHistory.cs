namespace Domain.Models;

public partial class PurchaseHistory
{
    public Guid PurchaseHistoryId { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? TimeOfPurchase { get; set; } // behövs TimeOfPurchase i historiken när den redan finns i kvittot?

    public int? TotalPrice { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual User? User { get; set; }
}