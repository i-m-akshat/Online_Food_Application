using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class OrderDetail
    {
        public long OrderDetailsId { get; set; }
        public long OrderId { get; set; }
        public long FoodId { get; set; }
        public decimal Amount { get; set; }
        public short NoOfServings { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
