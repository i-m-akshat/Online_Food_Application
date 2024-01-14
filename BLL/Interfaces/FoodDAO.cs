
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface FoodDAO
    {
        Task<bool> InsertFood(Food food);
        Task<bool> UpdateFood(long id, Food food);
        Task<bool> DeleteFood(long id,  Food food);
        Task<Food> GetFoodByID(long id);
        Task<FoodModel> GetAllFoodList(int CurrentPage);
        Task<List<Food>> GetAllCategories();
        Task<List<Food>> GetAllSubCategories();
        Task<List<Food>> GetAllFoodType();
    }
}
