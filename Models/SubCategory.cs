using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class SubCategory
    {
        public IFormFile imageFile_Banner { get; set; }
        public IFormFile imageFile_Icon { get; set; }
        public SubCategory()
        {
            FoodTypes = new HashSet<FoodType>();
            Foods = new HashSet<Food>();
        }
        [Display(Name = "SubCategory ID")]
        public int SubCatid { get; set; }
        public short CatId { get; set; }
        [Display(Name = "Category Name")]
        public string CatName { get; set; }
        [Display(Name = "Sub Category Name")]
        public string SubCatName { get; set; }
        [Display(Name = "Banner Image")]
        public byte[]? BannerImg { get; set; }
        [Display(Name = "Icon Image")]
        public byte[]? IconImg { get; set; }
        [Display(Name = "Description")]
        public string SubCatDescription { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Category Cat { get; set; }
        public virtual AdminSession? CreatedByNavigation { get; set; }
        public virtual AdminSession? DeletedByNavigation { get; set; }
        public virtual AdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<FoodType> FoodTypes { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
