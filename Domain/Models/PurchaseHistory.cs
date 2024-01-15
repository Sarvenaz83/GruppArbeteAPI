namespace Domain.Models;

public partial class PurchaseHistory
{
    public Guid PurchaseId { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? TimeOfPurchase { get; set; }

    public int? TotalPrice { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual User? User { get; set; }
}
