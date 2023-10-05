using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblProductImage
    {
        public long ProductImgId { get; set; }
        public byte[] ProductImg { get; set; } = null!;
        public long FoodId { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TblAdminSession? CreatedByNavigation { get; set; }
        public virtual TblAdminSession? DeletedByNavigation { get; set; }
        public virtual TblFood Food { get; set; } = null!;
        public virtual TblAdminSession? UpdatedByNavigation { get; set; }
    }
}
