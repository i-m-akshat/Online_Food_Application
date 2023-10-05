using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblFood
    {
        public TblFood()
        {
            TblCarts = new HashSet<TblCart>();
            TblOrderDetails = new HashSet<TblOrderDetail>();
            TblProductImages = new HashSet<TblProductImage>();
            TblRatings = new HashSet<TblRating>();
        }

        public long FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public short CatId { get; set; }
        public int SubCatId { get; set; }
        public int FoodTypeId { get; set; }
        public bool IsActive { get; set; }
        public byte[] IconImage { get; set; } = null!;
        public byte[] BannerImage { get; set; } = null!;
        public string FoodDesc { get; set; } = null!;
        public decimal FoodAmount { get; set; }
        public int? Quantity { get; set; }
        public bool ShowOnHomePage { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TblCategory Cat { get; set; } = null!;
        public virtual TblAdminSession? CreatedByNavigation { get; set; }
        public virtual TblAdminSession? DeletedByNavigation { get; set; }
        public virtual TblFoodType FoodType { get; set; } = null!;
        public virtual TblSubCategory SubCat { get; set; } = null!;
        public virtual TblAdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual ICollection<TblProductImage> TblProductImages { get; set; }
        public virtual ICollection<TblRating> TblRatings { get; set; }
    }
}
