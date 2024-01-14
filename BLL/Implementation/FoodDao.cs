using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class FoodDao : FoodDAO
    {
        public async Task<bool> DeleteFood(long id,Food food)
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    TblFood tbl = await _context.TblFoods.FindAsync((long)id);
                    if (tbl != null)
                    {
                        tbl.IsActive = false;
                        tbl.DeletedBy = food.DeletedBy;
                        tbl.DeletedDate = Convert.ToDateTime(DateTime.Now.ToString());
                        _context.TblFoods.Update(tbl);
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

        public async Task<List<Food>> GetAllCategories()
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    List<Food> listFood = _context.TblCategories.Where(x => x.IsActive == true).Select(x => new Food
                    {
                        CatId=x.CatId,
                        CategoryName=x.CatName
                    }).ToList();
                    return listFood;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FoodModel> GetAllFoodList(int CurrentPage)
        {
            try
            {
                int maxRows = 5;
                FoodModel _foodModel = new FoodModel();
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    _foodModel.listFoods = _context.TblFoods.Where(x => x.IsActive == true).Select(x => new Food
                    {
                        FoodId = x.FoodId,
                        FoodName = x.FoodName,
                        FoodDesc = x.FoodDesc,
                        FoodAmount = x.FoodAmount,
                        Quantity=(int)(x.Quantity),
                        FoodTypeId = x.FoodTypeId,
                        FoodTypeName=x.FoodType.FoodType,
                        SubCatId = x.SubCatId,
                        SubCategoryName=x.SubCat.SubCatName,
                        CatId = x.CatId,
                        CategoryName=x.Cat.CatName,
                        IsActive = x.IsActive,
                        BannerImage = x.BannerImage,
                        IconImage = x.IconImage,
                        ShowOnHomePage = x.ShowOnHomePage
                    }).Skip((CurrentPage-1)*maxRows).Take(maxRows).ToList();
                    double Pagecount = (double)((decimal)_context.TblFoods.Where(x => x.IsActive == true).Count() / Convert.ToDecimal(maxRows));
                    _foodModel.PageCount = (int)Math.Ceiling(Pagecount);
                    _foodModel.CurrentPageIndex = CurrentPage;
                    return _foodModel;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Food>> GetAllFoodType()
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    List<Food> listFood = _context.TblFoodTypes.Where(x => x.IsActive == true).Select(x => new Food
                    {
                        FoodTypeId=x.FoodTypeId,
                        FoodTypeName=x.FoodType
                    }).ToList();
                    return listFood;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Food>> GetAllSubCategories()
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                List<Food> listFood = _context.TblSubCategories.Where(x => x.IsActive == true).Select(x => new Food
                {
                    SubCatId=x.SubCatid,
                    SubCategoryName=x.SubCatName
                }).ToList();
                return listFood;
            }
        }

        public async Task<Food> GetFoodByID(long id)
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    
                        TblFood tbl = await _context.TblFoods.FindAsync((long)id);
                        if (tbl != null)
                        {
                            Food food = new Food
                            {
                                FoodId = tbl.FoodId,
                                FoodName = tbl.FoodName,
                                FoodDesc = tbl.FoodDesc,
                                FoodAmount = tbl.FoodAmount,
                                Quantity=(int)(tbl.Quantity),
                                FoodTypeId = tbl.FoodTypeId,
                                SubCatId = tbl.SubCatId,
                                CatId = tbl.CatId,
                                IsActive = tbl.IsActive,
                                BannerImage = tbl.BannerImage,
                                IconImage = tbl.IconImage,
                                ShowOnHomePage = tbl.ShowOnHomePage
                            };
                            return food;
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

        public async Task<bool> InsertFood(Food food)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                int FoodID =  _context.TblFoods.Max(x => (int?)x.FoodId) ?? 0;
                TblFood tbl = new TblFood();
                tbl.FoodId = (int)(FoodID+1);
                tbl.FoodName = food.FoodName;
                tbl.FoodDesc = food.FoodDesc;
                tbl.BannerImage = food.BannerImage;
                tbl.IconImage = food.IconImage;
                tbl.Quantity = food.Quantity;
                tbl.CatId=food.CatId;
                tbl.IsActive = true;
                tbl.SubCatId = food.SubCatId;
                tbl.CreatedBy = food.CreatedBy;
                tbl.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                tbl.FoodAmount=food.FoodAmount;
                tbl.FoodTypeId = food.FoodTypeId;
                tbl.ShowOnHomePage= food.ShowOnHomePage;
                _context.TblFoods.Add(tbl);
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<bool> UpdateFood(long id, Food food)
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    TblFood tbl = await _context.TblFoods.FindAsync((long)id);
                    if (tbl != null)
                    {
                        tbl.FoodName = food.FoodName;
                        tbl.FoodDesc = food.FoodDesc;
                        if (food.BannerImage != null)
                        {
                            tbl.BannerImage = food.BannerImage;
                        }
                        if (food.IconImage != null)
                        {
                            tbl.IconImage = food.IconImage;
                        }
                       
                        tbl.CatId = food.CatId;
                        tbl.IsActive = true;
                        tbl.SubCatId = food.SubCatId;
                        tbl.UpdatedBy = food.UpdatedBy;
                        tbl.UpdatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                        tbl.FoodAmount = food.FoodAmount;
                        tbl.Quantity = food.Quantity;
                        tbl.FoodTypeId = food.FoodTypeId;
                        tbl.ShowOnHomePage = food.ShowOnHomePage;
                        _context.TblFoods.Update(tbl);
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
