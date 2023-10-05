using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface SubCategoryDAO
    {
        public Task<List<SubCategory>> GetAllSubCategories(List<SubCategory> subCat);
        public Task<SubCategory> GetSubCategoryById(int? id, SubCategory subCat);
        public Task<bool> InsertSubCategory(SubCategory subCat);
        public Task<bool> UpdateSubCategory(int id, SubCategory subCat);
        public Task<bool> DeleteSubCategory(int id, SubCategory subCat);
        public Task<List<SubCategory>> GetCategoriesForDropdownList();
    }
}
