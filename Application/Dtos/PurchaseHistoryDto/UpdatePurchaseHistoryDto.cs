namespace Application.Dtos.PurchaseHistoryDto
{
    public class UpdatePurchaseHistoryDto
    {
        public Guid UserId { get; set; }
        public List<Guid> NewReceiptIds { get; set; } = new List<Guid>();
    }
}
