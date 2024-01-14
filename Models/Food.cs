using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class Food
    {

        public Food()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
            Ratings = new HashSet<Rating>();
        }
        public IFormFile imageFile_Banner { get; set; }
        public IFormFile imageFile_Icon { get; set; }
        public long FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public short CatId { get; set; }
        public string CategoryName { get; set; }
        public int SubCatId { get; set; }
        public string SubCategoryName { get; set; }
        public int FoodTypeId { get; set; }
        public string FoodTypeName { get; set; }
        public bool IsActive { get; set; }
        public byte[] IconImage { get; set; } = null!;
        public byte[] BannerImage { get; set; } = null!;
        public string FoodDesc { get; set; } = null!;
        public decimal FoodAmount { get; set; }
        public int Quantity { get; set; }
        public bool ShowOnHomePage { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Category Cat { get; set; } = null!;
        public virtual AdminSession? CreatedByNavigation { get; set; }
        public virtual AdminSession? DeletedByNavigation { get; set; }
        public virtual FoodType FoodType { get; set; } = null!;
        public virtual SubCategory SubCat { get; set; } = null!;
        public virtual AdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }



    }

    public class FoodModel
    {
        public List<Food> listFoods { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
