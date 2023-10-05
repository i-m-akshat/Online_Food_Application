using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblFoodType
    {
        public TblFoodType()
        {
            TblFoods = new HashSet<TblFood>();
        }

        public int FoodTypeId { get; set; }
        public string FoodType { get; set; } = null!;
        public bool IsActive { get; set; }
        public byte[] FoodTypeImg { get; set; } = null!;
        public string FoodTypeDesc { get; set; } = null!;
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TblAdminSession? CreatedByNavigation { get; set; }
        public virtual TblAdminSession? DeletedByNavigation { get; set; }
        public virtual TblAdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<TblFood> TblFoods { get; set; }
    }
}
