using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblAdminSession
    {
        public TblAdminSession()
        {
            TblCategoryCreatedByNavigations = new HashSet<TblCategory>();
            TblCategoryDeletedByNavigations = new HashSet<TblCategory>();
            TblCategoryUpdatedByNavigations = new HashSet<TblCategory>();
            TblFoodCreatedByNavigations = new HashSet<TblFood>();
            TblFoodDeletedByNavigations = new HashSet<TblFood>();
            TblFoodTypeCreatedByNavigations = new HashSet<TblFoodType>();
            TblFoodTypeDeletedByNavigations = new HashSet<TblFoodType>();
            TblFoodTypeUpdatedByNavigations = new HashSet<TblFoodType>();
            TblFoodUpdatedByNavigations = new HashSet<TblFood>();
            TblProductImageCreatedByNavigations = new HashSet<TblProductImage>();
            TblProductImageDeletedByNavigations = new HashSet<TblProductImage>();
            TblProductImageUpdatedByNavigations = new HashSet<TblProductImage>();
            TblRatingCreatedbyNavigations = new HashSet<TblRating>();
            TblRatingDeletedByNavigations = new HashSet<TblRating>();
            TblRatingUpdatedByNavigations = new HashSet<TblRating>();
            TblRoleCreatedByNavigations = new HashSet<TblRole>();
            TblRoleDeletedByNavigations = new HashSet<TblRole>();
            TblRoleUpdatedByNavigations = new HashSet<TblRole>();
            TblSubCategoryCreatedByNavigations = new HashSet<TblSubCategory>();
            TblSubCategoryDeletedByNavigations = new HashSet<TblSubCategory>();
            TblSubCategoryUpdatedByNavigations = new HashSet<TblSubCategory>();
        }

        public long AdminSessionId { get; set; }
        public int AdminId { get; set; }
        public DateTime? SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }

        public virtual TblAdmin Admin { get; set; } = null!;
        public virtual ICollection<TblCategory> TblCategoryCreatedByNavigations { get; set; }
        public virtual ICollection<TblCategory> TblCategoryDeletedByNavigations { get; set; }
        public virtual ICollection<TblCategory> TblCategoryUpdatedByNavigations { get; set; }
        public virtual ICollection<TblFood> TblFoodCreatedByNavigations { get; set; }
        public virtual ICollection<TblFood> TblFoodDeletedByNavigations { get; set; }
        public virtual ICollection<TblFoodType> TblFoodTypeCreatedByNavigations { get; set; }
        public virtual ICollection<TblFoodType> TblFoodTypeDeletedByNavigations { get; set; }
        public virtual ICollection<TblFoodType> TblFoodTypeUpdatedByNavigations { get; set; }
        public virtual ICollection<TblFood> TblFoodUpdatedByNavigations { get; set; }
        public virtual ICollection<TblProductImage> TblProductImageCreatedByNavigations { get; set; }
        public virtual ICollection<TblProductImage> TblProductImageDeletedByNavigations { get; set; }
        public virtual ICollection<TblProductImage> TblProductImageUpdatedByNavigations { get; set; }
        public virtual ICollection<TblRating> TblRatingCreatedbyNavigations { get; set; }
        public virtual ICollection<TblRating> TblRatingDeletedByNavigations { get; set; }
        public virtual ICollection<TblRating> TblRatingUpdatedByNavigations { get; set; }
        public virtual ICollection<TblRole> TblRoleCreatedByNavigations { get; set; }
        public virtual ICollection<TblRole> TblRoleDeletedByNavigations { get; set; }
        public virtual ICollection<TblRole> TblRoleUpdatedByNavigations { get; set; }
        public virtual ICollection<TblSubCategory> TblSubCategoryCreatedByNavigations { get; set; }
        public virtual ICollection<TblSubCategory> TblSubCategoryDeletedByNavigations { get; set; }
        public virtual ICollection<TblSubCategory> TblSubCategoryUpdatedByNavigations { get; set; }
    }
}
