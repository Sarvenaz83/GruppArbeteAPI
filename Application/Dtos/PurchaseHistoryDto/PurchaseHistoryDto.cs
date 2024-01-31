using System;
using System.Collections.Generic;
using Application.Dtos.ReceiptDto;
using Domain.Models;

namespace Application.Dtos.PurchaseHistoryDto
{
    public class PurchaseHistoryDto
    {
        public Guid? PurchaseHistoryId { get; set; }
        public Guid? UserId { get; set; }
        public List<ReceiptDto.ReceiptDto> Receipts { get; set; } = new List<ReceiptDto.ReceiptDto>();
    }
}
