using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class AdminSession
    {
        public AdminSession()
        {
            CategoryCreatedByNavigations = new HashSet<Category>();
            CategoryDeletedByNavigations = new HashSet<Category>();
            CategoryUpdatedByNavigations = new HashSet<Category>();
            FoodCreatedByNavigations = new HashSet<Food>();
            FoodDeletedByNavigations = new HashSet<Food>();
            FoodTypeCreatedByNavigations = new HashSet<FoodType>();
            FoodTypeDeletedByNavigations = new HashSet<FoodType>();
            FoodTypeUpdatedByNavigations = new HashSet<FoodType>();
            FoodUpdatedByNavigations = new HashSet<Food>();
            ProductImageCreatedByNavigations = new HashSet<ProductImage>();
            ProductImageDeletedByNavigations = new HashSet<ProductImage>();
            ProductImageUpdatedByNavigations = new HashSet<ProductImage>();
            RatingCreatedbyNavigations = new HashSet<Rating>();
            RatingDeletedByNavigations = new HashSet<Rating>();
            RatingUpdatedByNavigations = new HashSet<Rating>();
            RoleCreatedByNavigations = new HashSet<Role>();
            RoleDeletedByNavigations = new HashSet<Role>();
            RoleUpdatedByNavigations = new HashSet<Role>();
            SubCategoryCreatedByNavigations = new HashSet<SubCategory>();
            SubCategoryDeletedByNavigations = new HashSet<SubCategory>();
            SubCategoryUpdatedByNavigations = new HashSet<SubCategory>();
        }

        public long AdminSessionId { get; set; }
        public int AdminId { get; set; }
        public DateTime? SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }

        public virtual Admin Admin { get; set; } = null!;
        public virtual ICollection<Category> CategoryCreatedByNavigations { get; set; }
        public virtual ICollection<Category> CategoryDeletedByNavigations { get; set; }
        public virtual ICollection<Category> CategoryUpdatedByNavigations { get; set; }
        public virtual ICollection<Food> FoodCreatedByNavigations { get; set; }
        public virtual ICollection<Food> FoodDeletedByNavigations { get; set; }
        public virtual ICollection<FoodType> FoodTypeCreatedByNavigations { get; set; }
        public virtual ICollection<FoodType> FoodTypeDeletedByNavigations { get; set; }
        public virtual ICollection<FoodType> FoodTypeUpdatedByNavigations { get; set; }
        public virtual ICollection<Food> FoodUpdatedByNavigations { get; set; }
        public virtual ICollection<ProductImage> ProductImageCreatedByNavigations { get; set; }
        public virtual ICollection<ProductImage> ProductImageDeletedByNavigations { get; set; }
        public virtual ICollection<ProductImage> ProductImageUpdatedByNavigations { get; set; }
        public virtual ICollection<Rating> RatingCreatedbyNavigations { get; set; }
        public virtual ICollection<Rating> RatingDeletedByNavigations { get; set; }
        public virtual ICollection<Rating> RatingUpdatedByNavigations { get; set; }
        public virtual ICollection<Role> RoleCreatedByNavigations { get; set; }
        public virtual ICollection<Role> RoleDeletedByNavigations { get; set; }
        public virtual ICollection<Role> RoleUpdatedByNavigations { get; set; }
        public virtual ICollection<SubCategory> SubCategoryCreatedByNavigations { get; set; }
        public virtual ICollection<SubCategory> SubCategoryDeletedByNavigations { get; set; }
        public virtual ICollection<SubCategory> SubCategoryUpdatedByNavigations { get; set; }
    }
}
