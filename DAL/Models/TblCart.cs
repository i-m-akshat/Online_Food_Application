using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblCart
    {
        public short CartId { get; set; }
        public long FoodId { get; set; }
        public int Quantity { get; set; }
        public long UserId { get; set; }
        public string CartStatus { get; set; } = null!;
        public DateTime? AddedDate { get; set; }

        public virtual TblFood Food { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
