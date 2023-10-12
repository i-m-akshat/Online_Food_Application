using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface HomePageDAO
    {
        Task<List<Category>> GetCategoriesForHomepage();
        Task<List<SubCategory>> GetSubCategoriesForHomePage(int _catId);
        Task<List<FoodType>> GetFoodTypeForHomePage();
        Task<List<Food>> GetAllFoods();
        Task<List<Food>> GetFoodsForHomepage();
        Task<List<Food>> GetTopRatingFood();
        Task<List<Category>> GetAllCategories();
        Task<List<FoodType>> GetAllFoodTypes();
        Task<User> GetUserDetails(int id);
        Task<List<SubCategory>> GetAllSubCategories(List<SubCategory> subCat);
    }
}
