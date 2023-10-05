using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class Category
    {

        public Category()
        {
            FoodTypes = new HashSet<FoodType>();
            Foods = new HashSet<Food>();
            SubCategories = new HashSet<SubCategory>();
        }
        public IFormFile imageFile_Banner { get; set; }
        public IFormFile imageFile_Icon { get; set; }
        [Display(Name = "Category ID")]
        public short CatId { get; set; }
        [Display(Name = "Category Name")]
        public string CatName { get; set; } = null!;
        public bool IsActive { get; set; }
        [Display(Name = "Category Description")]
        public string CatDesc { get; set; } = null!;
        public bool ShowOnHomepage { get; set; }
        [Display(Name = "Banner Image")]
        public byte[] BannerImage { get; set; } = null!;
        [Display(Name = "Icon image")]
        public byte[] IconImage { get; set; } = null!;
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual AdminSession? CreatedByNavigation { get; set; }
        public virtual AdminSession? DeletedByNavigation { get; set; }
        public virtual AdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<FoodType> FoodTypes { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
