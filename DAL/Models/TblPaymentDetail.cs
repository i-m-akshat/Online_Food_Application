using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblPaymentDetail
    {
        public TblPaymentDetail()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public long PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaidBy { get; set; } = null!;
        public DateTime? PaymentDate { get; set; }
        public long ProcessedBy { get; set; }
        public string? TransactionId { get; set; }

        public virtual TblUser ProcessedByNavigation { get; set; } = null!;
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
