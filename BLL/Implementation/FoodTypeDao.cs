
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
    public class FoodTypeDao : FoodTypeDAO
    {
        public async Task<bool> DeleteFoodType(int id, FoodType foodType)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    TblFoodType tbl = await _context.TblFoodTypes.FindAsync((int)id);
                    if (tbl != null)
                    {
                        tbl.IsActive = false;
                        tbl.DeletedDate = Convert.ToDateTime(DateTime.Now.ToString());
                        tbl.DeletedBy = foodType.DeletedBy;
                        _context.TblFoodTypes.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FoodType>> GetAllFoodTypes()
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    List<FoodType> list = new List<FoodType>();
                    list = _context.TblFoodTypes.Where(x => x.IsActive == true).Select(
                        x => new FoodType()
                        {
                            FoodTypeId = x.FoodTypeId,
                            FoodTypeImg = x.FoodTypeImg,
                            FoodTypeName = x.FoodType,
                            IsActive = x.IsActive,
                            FoodTypeDesc = x.FoodTypeDesc,
                            //SubCatid = (int)x.SubCatid,
                            //SubCategoryName = x.SubCat.SubCatName,
                            //CatId = x.CatId,
                            //CategoryName = x.Cat.CatName
                        }
                        ).ToList();
                    return list;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FoodType> GetFoodTypeById(int id)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    TblFoodType tbl = await _context.TblFoodTypes.FindAsync((int)id);
                    if (tbl != null)
                    {
                        FoodType foodType = new FoodType
                        {
                            FoodTypeId = tbl.FoodTypeId,
                            FoodTypeName = tbl.FoodType,
                            FoodTypeDesc = tbl.FoodTypeDesc,
                            FoodTypeImg = tbl.FoodTypeImg,
                            //SubCatid = (int)tbl.SubCatid,
                            //SubCategoryName = tbl.SubCat.SubCatName,
                            //CategoryName = tbl.Cat.CatName,
                            //CatId=tbl.CatId
                        };
                        return foodType;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> InsertFoodType(FoodType foodType)
        {
            try
            {
                if (foodType != null)
                {
                    await using (var _context = new Online_Food_ApplicationContext())
                    {
                        int FoodTypeId = _context.TblFoodTypes.Max(x => (int?)x.FoodTypeId) ?? 0;
                        TblFoodType tbl = new TblFoodType();
                        tbl.FoodTypeId = (int)(FoodTypeId + 1);
                        tbl.FoodType = foodType.FoodTypeName;
                        //tbl.SubCatid = Convert.ToInt32(foodType.SubCatid);
                        //tbl.CatId = (short)(foodType.CatId);
                        tbl.IsActive = true;
                        tbl.FoodTypeDesc = foodType.FoodTypeDesc;
                        tbl.FoodTypeImg = foodType.FoodTypeImg;
                        tbl.CreatedBy = null;
                        tbl.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                        _context.TblFoodTypes.Add(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateFoodType(int id, FoodType foodType)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    TblFoodType tbl = await _context.TblFoodTypes.FindAsync((int)id);
                    if (tbl != null)
                    {
                        tbl.FoodType = foodType.FoodTypeName;
                        tbl.FoodTypeDesc = foodType.FoodTypeDesc;
                        if (foodType.FoodTypeImg != null)
                        {
                            tbl.FoodTypeImg = foodType.FoodTypeImg;
                        }
                        //tbl.SubCatid = foodType.SubCatid;
                        //tbl.CatId = foodType.CatId;
                        tbl.UpdatedBy = null;
                        tbl.UpdatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                        _context.TblFoodTypes.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<FoodType>> getAllCategoriesForDropdown()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                List<FoodType> listFood = new List<FoodType>();
                listFood=_context.TblCategories.Where(x => x.IsActive == true).Select(x => new FoodType
                {
                    CategoryName = x.CatName,
                    CatId = x.CatId
                }).ToList();
                return listFood;
            }

        }
        public async Task<List<FoodType>> getAllSubCategoriesForDropdown()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                List<FoodType> listFood = new List<FoodType>();
                listFood=_context.TblSubCategories.Where(x => x.IsActive == true).Select(x => new FoodType
                {
                    SubCatid = x.SubCatid,
                    SubCategoryName = x.SubCatName
                    
                }).ToList();
                return listFood;
            }

        }
    }
}
