using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface CategoryDAO
    {
        public Task<CategoryModel> GetAllCategories(int CurrentPageIndex);
        public Task<Category> GetCategoryDetails(int? CategoryID);
        public Task<bool> InsertCategory(Category category);
        public Task<bool> UpdateCategoryDetails(int id, Category category);
        public Task<bool> DeleteCategoryDetails(int id, Category category);
        
    }
}
