using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long? PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = null!;
        public long ProcessedBy { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public virtual TblPaymentDetail? Payment { get; set; }
        public virtual TblUser ProcessedByNavigation { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
