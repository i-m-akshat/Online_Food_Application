using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblPaymentDetail
    {
        public long PaymentId { get; set; }
        public long OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaidBy { get; set; } = null!;
        public DateTime? PaymentDate { get; set; }
        public long ProcessedBy { get; set; }
        public string? TransactionId { get; set; }

        public virtual TblOrder Order { get; set; } = null!;
        public virtual TblUser ProcessedByNavigation { get; set; } = null!;
    }
}
