using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long? PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = null!;
        public long ProcessedBy { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string ProcessedBy_Name { get; set; }
        public long OrderDetailsId { get; set; }
        public long FoodId { get; set; }
        public string FoodName { get; set; }    
        public decimal Amount { get; set; }
        public short NoOfServings { get; set; }
        public virtual PaymentDetail? Payment { get; set; }
        public virtual User ProcessedByNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
