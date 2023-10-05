using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class CategoryDao : CategoryDAO
    {
        
        public async Task<bool> DeleteCategoryDetails(int id,Category category)
        {
            try
            {
                await using(var _context = new Online_Food_ApplicationContext())
                {
                    TblCategory tbl = await _context.TblCategories.FindAsync((short)id);
                    if (id == tbl.CatId)
                    {
                        tbl.IsActive = false;
                        tbl.DeletedDate = Convert.ToDateTime(DateTime.Now.Date);
                        tbl.DeletedBy= category.UpdatedBy;
                        _context.TblCategories.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Category>> GetAllCategories(List<Category> categories)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    categories = _context.TblCategories.Where(x => x.IsActive == true).Select(x => new Category()
                    {
                        CatName = x.CatName,
                        CatId = x.CatId,
                        CatDesc = x.CatDesc,
                        BannerImage = x.BannerImage,
                        IconImage = x.IconImage

                    }).ToList();
                    return categories;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Category> GetCategoryDetails(int? CategoryID)
        {
            try
            {

                await using (var _context = new Online_Food_ApplicationContext())
                {
                    Category category = new Category();
                    category = _context.TblCategories.Select(x => new Category()
                    {
                        CatDesc = x.CatDesc,
                        CatId = x.CatId,
                        CatName = x.CatName,
                        BannerImage = x.BannerImage,
                        IconImage = x.IconImage,
                        ShowOnHomepage=x.ShowOnHomepage,
                        IsActive=x.IsActive
                    }).Where(x => x.CatId == CategoryID).FirstOrDefault();
                    return category;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> InsertCategory(Category category)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    int CategoryID = _context.TblCategories.Max(x => (int?)x.CatId) ?? 0;//The ?? operator is called the null coalescing operator. It is used to return the 
                    //first non-null value of two expressions. If value is not null, then it is returned. Otherwise, default_value is returned.
                    TblCategory tbl = new TblCategory();
                    tbl.CatId = (short)(CategoryID + 1);
                    tbl.CatName = category.CatName;
                    tbl.CatDesc = category.CatDesc;
                    tbl.ShowOnHomepage = category.ShowOnHomepage;
                    tbl.BannerImage = category.BannerImage;
                    tbl.IconImage = category.IconImage;
                    tbl.IsActive = true;
                    tbl.CreatedBy = category.CreatedBy;
                    tbl.CreatedDate = Convert.ToDateTime(DateTime.Now.Date);
                    _context.TblCategories.Add(tbl);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateCategoryDetails(int id, Category category)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {

                    TblCategory tbl = await _context.TblCategories.FindAsync((short)id);

                    if (id == Convert.ToInt32(tbl.CatId))
                    {
                        tbl.CatName = category.CatName;
                        tbl.CatDesc = category.CatDesc;
                        tbl.ShowOnHomepage = category.ShowOnHomepage;
                        if (category.BannerImage != null)
                        {
                            tbl.BannerImage = category.BannerImage;
                        }
                        if (category.IconImage != null)
                        {
                            tbl.IconImage = category.IconImage;
                        }
                        tbl.IsActive = true;
                        tbl.UpdatedBy = category.UpdatedBy;
                        tbl.UpdatedDate = Convert.ToDateTime(DateTime.Now.Date);
                        _context.TblCategories.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
}
        
    }
}
