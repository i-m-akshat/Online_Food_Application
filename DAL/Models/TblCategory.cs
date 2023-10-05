using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblFoods = new HashSet<TblFood>();
            TblSubCategories = new HashSet<TblSubCategory>();
        }

        public short CatId { get; set; }
        public string CatName { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CatDesc { get; set; } = null!;
        public bool ShowOnHomepage { get; set; }
        public byte[] BannerImage { get; set; } = null!;
        public byte[] IconImage { get; set; } = null!;
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
        public virtual ICollection<TblSubCategory> TblSubCategories { get; set; }
    }
}
