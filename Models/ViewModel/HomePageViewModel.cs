using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class HomePageViewModel
    {
        public List<Category> TopCategories { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<FoodType> FoodTypes { get; set; }
        public List<Food> Food { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
