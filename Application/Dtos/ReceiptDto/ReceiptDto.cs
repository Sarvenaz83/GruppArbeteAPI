using System;

namespace Application.Dtos.ReceiptDto
{
    public class ReceiptDto
    {
        public Guid ReceiptId { get; set; }
        public Guid? BookId { get; set; }
        public int? Quantity { get; set; }
        public int? PricePerUnit { get; set; }
        public DateTime? DateDetail { get; set; }
    }
}


