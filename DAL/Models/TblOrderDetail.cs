using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblOrderDetail
    {
        public long OrderDetailsId { get; set; }
        public long OrderId { get; set; }
        public long FoodId { get; set; }
        public decimal Amount { get; set; }
        public short NoOfServings { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual TblFood Food { get; set; } = null!;
        public virtual TblOrder Order { get; set; } = null!;
    }
}
