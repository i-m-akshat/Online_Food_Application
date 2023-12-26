using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface HomePageDAO
    {
        Task<long> getFoodByName(string Name);
        Task<List<string>> getAllFoodNames();
        Task<List<FoodType>> GetAllFoodTypesForHomepage();
        Task<List<Category>> GetCategoriesForHomepage();
        Task<List<SubCategory>> GetSubCategoriesForHomePage(List<int> list);
        Task<List<SubCategory>> GetSubCategoriesForHomePage();
        Task<HomePageViewModel> GetFoodTypeForHomePage(int _subCatID);
        Task<List<Food>> GetAllFoods();
        Task<List<Food>> GetFoodsForHomepage();
        Task<List<Food>> GetTopRatingFood();
        Task<List<Category>> GetAllCategories();
        Task<List<FoodType>> GetAllFoodTypes();
        Task<User> GetUserDetails(int id);
        Task<List<SubCategory>> GetAllSubCategories(List<SubCategory> subCat);
        Task<List<Food>> GetAllFoods_Filter(List<int>? listCat, List<int>? listSubCat, List<int>? listFoodType);
        Task<Food> GetFoodByID(long id);
        Task<List<Food>> getFoodsByFoodTypoeID(int foodTypeid);
        Task<List<Food>> getFoodsByCategoryID(int Catid);
        Task<List<Food>> getFoodsBySubCategoryID(int SubCatid);
    }
}
