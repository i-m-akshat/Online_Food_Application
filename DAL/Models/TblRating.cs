using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblRating
    {
        public long RatingId { get; set; }
        public short Rating { get; set; }
        public string Remarks { get; set; } = null!;
        public long UserId { get; set; }
        public long FoodId { get; set; }
        public long? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedBy { get; set; }

        public virtual TblAdminSession? CreatedbyNavigation { get; set; }
        public virtual TblAdminSession? DeletedByNavigation { get; set; }
        public virtual TblFood Food { get; set; } = null!;
        public virtual TblAdminSession? UpdatedByNavigation { get; set; }
        public virtual TblUser User { get; set; } = null!;
    }
}
