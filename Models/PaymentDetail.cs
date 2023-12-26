using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class PaymentDetail
    {
        public PaymentDetail()
        {
            Orders = new HashSet<Order>();
        }

        public long PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaidBy { get; set; } = null!;
        public DateTime? PaymentDate { get; set; }
        public long ProcessedBy { get; set; }
        public string? TransactionId { get; set; }

        public virtual User ProcessedByNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
