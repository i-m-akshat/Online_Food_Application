using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblSubCategory
    {
        public TblSubCategory()
        {
            TblFoods = new HashSet<TblFood>();
        }

        public int SubCatid { get; set; }
        public short? CatId { get; set; }
        public string? SubCatName { get; set; }
        public byte[]? BannerImg { get; set; }
        public byte[]? IconImg { get; set; }
        public string? SubCatDescription { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TblCategory? Cat { get; set; }
        public virtual TblAdminSession? CreatedByNavigation { get; set; }
        public virtual TblAdminSession? DeletedByNavigation { get; set; }
        public virtual TblAdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<TblFood> TblFoods { get; set; }
    }
}
