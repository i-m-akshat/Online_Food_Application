using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface FoodTypeDAO
    {
        Task<List<FoodType>> GetAllFoodTypes(); 
        Task<FoodType> GetFoodTypeById(int id);
        Task<bool> InsertFoodType(FoodType foodType);
        Task<bool> UpdateFoodType(int id, FoodType foodType);
        Task<bool> DeleteFoodType(int id,FoodType foodType);
        Task<List<FoodType>> getAllCategoriesForDropdown();
        Task<List<FoodType>> getAllSubCategoriesForDropdown();
    }
}
