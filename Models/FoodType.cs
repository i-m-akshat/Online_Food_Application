using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class FoodType
    {
        public IFormFile ImageFile_FoodType { get; set; }
        public FoodType()
        {
            Foods = new HashSet<Food>();
        }

        public int FoodTypeId { get; set; }
        [Display(Name = "Name Of Food Type")]
        public string FoodTypeName { get; set; } = null!;
        public int SubCatid { get; set; }
        [Display(Name = "Sub-Category")]
        public string SubCategoryName { get; set; }
        public short CatId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Image")]
        public byte[] FoodTypeImg { get; set; } = null!;
        [Display(Name = "Description")]
        public string FoodTypeDesc { get; set; } = null!;
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

       
        public virtual AdminSession? CreatedByNavigation { get; set; }
        public virtual AdminSession? DeletedByNavigation { get; set; }
        public virtual AdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
