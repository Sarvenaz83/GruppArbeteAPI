using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PurchaseHistoryDto
{
    public class UpdatePurchaseHistoryDto
    {
        public Guid UserId { get; set; }
        public List<Guid> NewReceiptIds { get; set; } = new List<Guid>();
    }
}
