using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class HomePageDao : HomePageDAO
    {
        public async Task<List<SubCategory>> GetAllSubCategories(List<SubCategory> subCat)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    subCat = _context.TblSubCategories.Where(x => x.IsActive == true && x.Cat.IsActive == true).Select(x => new SubCategory()
                    {
                        SubCatid = x.SubCatid,
                        SubCatName = x.SubCatName,
                        SubCatDescription = x.SubCatDescription,
                        BannerImg = x.BannerImg,
                        IconImg = x.IconImg,
                        CatId = (short)(x.CatId),
                        CatName = x.Cat.CatName
                    }).ToList();
                    return subCat;
                }
            }
            catch (Exception ex)
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
        public async Task<List<Category>> GetCategoriesForHomepage()
        {
           await using (var _Context=new Online_Food_ApplicationContext())
            {
                List<Category> listCat= _Context.TblCategories.Where(x=>x.ShowOnHomepage==true&&x.IsActive==true).Select(x => new Category()
                {
                    CatName = x.CatName,
                    CatId = x.CatId,
                    CatDesc = x.CatDesc,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage

                }).Take(3).OrderBy(x=>x.CatId).ToList();
                return listCat;
            }
        }
       

        public async Task<List<Food>> GetFoodsForHomepage()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                List<Food> list = _context.TblFoods.Where(x => x.IsActive == true).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    FoodDesc = x.FoodDesc,
                    FoodAmount = x.FoodAmount,
                    Quantity = (int)(x.Quantity),
                    FoodTypeId = x.FoodTypeId,
                    FoodTypeName = x.FoodType.FoodType,
                    SubCatId = x.SubCatId,
                    SubCategoryName = x.SubCat.SubCatName,
                    CatId = x.CatId,
                    CategoryName = x.Cat.CatName,
                    IsActive = x.IsActive,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage,
                    ShowOnHomePage = x.ShowOnHomePage
                }
                    ).Take(3).OrderBy(x=>x.FoodId).ToList();
                return list;
            }
        }
        public async Task<List<Food>> GetAllFoods()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                List<Food> list = _context.TblFoods.Where(x => x.IsActive == true).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    FoodDesc = x.FoodDesc,
                    FoodAmount = x.FoodAmount,
                    Quantity = (int)(x.Quantity),
                    FoodTypeId = x.FoodTypeId,
                    FoodTypeName = x.FoodType.FoodType,
                    SubCatId = x.SubCatId,
                    SubCategoryName = x.SubCat.SubCatName,
                    CatId = x.CatId,
                    CategoryName = x.Cat.CatName,
                    IsActive = x.IsActive,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage,
                    ShowOnHomePage = x.ShowOnHomePage
                }
                    ).ToList();
                return list;
            }
        }
        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    List<Category> listCat = _context.TblCategories.Where(x => x.IsActive == true).Select(x => new Category()
                    {
                        CatName = x.CatName,
                        CatId = x.CatId,
                        CatDesc = x.CatDesc,
                        BannerImage = x.BannerImage,
                        IconImage = x.IconImage

                    }).ToList();
                    return listCat;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<HomePageViewModel> GetFoodTypeForHomePage(int _subCatId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SubCategory>> GetSubCategoriesForHomePage(List<int> list)
        {
            await using(var _context= new Online_Food_ApplicationContext())
            {
               
                List<SubCategory> listSub = _context.TblSubCategories.Where(x => list.Contains((int)x.CatId) && x.IsActive == true).Select(
                    x => new SubCategory
                    {
                        SubCatid = x.SubCatid,
                        SubCatName = x.SubCatName,
                        SubCatDescription = x.SubCatDescription,
                        BannerImg = x.BannerImg,
                        IconImg = x.IconImg,
                        CatId = (short)(x.CatId),
                        CatName = x.Cat.CatName
                    }).ToList();
                return listSub;
            }
        }
        public async Task<List<SubCategory>> GetSubCategoriesForHomePage()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {

                List<SubCategory> listSub = _context.TblSubCategories.Where(x=>x.IsActive == true).Select(
                    x => new SubCategory
                    {
                        SubCatid = x.SubCatid,
                        SubCatName = x.SubCatName,
                        SubCatDescription = x.SubCatDescription,
                        BannerImg = x.BannerImg,
                        IconImg = x.IconImg,
                        CatId = (short)(x.CatId),
                        CatName = x.Cat.CatName
                    }).Take(3).OrderBy(x=>x.SubCatid).ToList();
                return listSub;
            }
        }
        public Task<List<Food>> GetTopRatingFood()
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetUserDetails(int id)
        {
            try
            {
              await using(var _context= new Online_Food_ApplicationContext())
                {
                    var userdetails=_context.TblUsers.Where(x=>x.UserId==id).Select(x => new User()
                    {
                        FullName = x.FullName,
                        Password = x.Password,
                        UserId = x.UserId,
                        UserName = x.UserName,
                        Image = x.Image,
                        PhoneNumber = x.PhoneNumber,
                        IsActive = x.IsActive
                    }).FirstOrDefault();
                    return userdetails;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Food>> GetAllFoods_Filter(List<int>? listCat, List<int>? listSubCat, List<int>? listFoodType)
        {
            List<Food> listFood = new List<Food>();
            await using (var _context=new Online_Food_ApplicationContext())
            {
                if (listCat.Count != 0)
                {
                    if(listSubCat.Count != 0)
                    {

                        if (listFoodType.Count != 0)
                        {
                            listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && listFoodType.Contains(x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                            {
                                FoodId = x.FoodId,
                                FoodName = x.FoodName,
                                FoodDesc = x.FoodDesc,
                                FoodAmount = x.FoodAmount,
                                Quantity = (int)(x.Quantity),
                                FoodTypeId = x.FoodTypeId,
                                FoodTypeName = x.FoodType.FoodType,
                                SubCatId = x.SubCatId,
                                SubCategoryName = x.SubCat.SubCatName,
                                CatId = x.CatId,
                                CategoryName = x.Cat.CatName,
                                IsActive = x.IsActive,
                                BannerImage = x.BannerImage,
                                IconImage = x.IconImage,
                                ShowOnHomePage = x.ShowOnHomePage
                            }).ToList();
                        }
                        else
                        {
                            listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && x.IsActive == true).Select(x => new Food
                            {
                                FoodId = x.FoodId,
                                FoodName = x.FoodName,
                                FoodDesc = x.FoodDesc,
                                FoodAmount = x.FoodAmount,
                                Quantity = (int)(x.Quantity),
                                FoodTypeId = x.FoodTypeId,
                                FoodTypeName = x.FoodType.FoodType,
                                SubCatId = x.SubCatId,
                                SubCategoryName = x.SubCat.SubCatName,
                                CatId = x.CatId,
                                CategoryName = x.Cat.CatName,
                                IsActive = x.IsActive,
                                BannerImage = x.BannerImage,
                                IconImage = x.IconImage,
                                ShowOnHomePage = x.ShowOnHomePage
                            }).ToList();
                        }

                    }
                    else
                    {
                        listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId)  && x.IsActive == true).Select(x => new Food
                        {
                            FoodId = x.FoodId,
                            FoodName = x.FoodName,
                            FoodDesc = x.FoodDesc,
                            FoodAmount = x.FoodAmount,
                            Quantity = (int)(x.Quantity),
                            FoodTypeId = x.FoodTypeId,
                            FoodTypeName = x.FoodType.FoodType,
                            SubCatId = x.SubCatId,
                            SubCategoryName = x.SubCat.SubCatName,
                            CatId = x.CatId,
                            CategoryName = x.Cat.CatName,
                            IsActive = x.IsActive,
                            BannerImage = x.BannerImage,
                            IconImage = x.IconImage,
                            ShowOnHomePage = x.ShowOnHomePage
                        }).ToList();
                    }
                }
                else if(listSubCat.Count != 0)
                {
                    if (listCat.Count != 0)
                    {
                        if (listFood.Count != 0)
                        {
                            listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && listFoodType.Contains(x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                            {
                                FoodId = x.FoodId,
                                FoodName = x.FoodName,
                                FoodDesc = x.FoodDesc,
                                FoodAmount = x.FoodAmount,
                                Quantity = (int)(x.Quantity),
                                FoodTypeId = x.FoodTypeId,
                                FoodTypeName = x.FoodType.FoodType,
                                SubCatId = x.SubCatId,
                                SubCategoryName = x.SubCat.SubCatName,
                                CatId = x.CatId,
                                CategoryName = x.Cat.CatName,
                                IsActive = x.IsActive,
                                BannerImage = x.BannerImage,
                                IconImage = x.IconImage,
                                ShowOnHomePage = x.ShowOnHomePage
                            }).ToList();
                        }
                        else
                        {
                            listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && x.IsActive == true).Select(x => new Food
                            {
                                FoodId = x.FoodId,
                                FoodName = x.FoodName,
                                FoodDesc = x.FoodDesc,
                                FoodAmount = x.FoodAmount,
                                Quantity = (int)(x.Quantity),
                                FoodTypeId = x.FoodTypeId,
                                FoodTypeName = x.FoodType.FoodType,
                                SubCatId = x.SubCatId,
                                SubCategoryName = x.SubCat.SubCatName,
                                CatId = x.CatId,
                                CategoryName = x.Cat.CatName,
                                IsActive = x.IsActive,
                                BannerImage = x.BannerImage,
                                IconImage = x.IconImage,
                                ShowOnHomePage = x.ShowOnHomePage
                            }).ToList();
                        }
                    }
                    else
                    {
                        listFood = _context.TblFoods.Where(x =>  listSubCat.Contains(x.SubCatId) && x.IsActive == true).Select(x => new Food
                        {
                            FoodId = x.FoodId,
                            FoodName = x.FoodName,
                            FoodDesc = x.FoodDesc,
                            FoodAmount = x.FoodAmount,
                            Quantity = (int)(x.Quantity),
                            FoodTypeId = x.FoodTypeId,
                            FoodTypeName = x.FoodType.FoodType,
                            SubCatId = x.SubCatId,
                            SubCategoryName = x.SubCat.SubCatName,
                            CatId = x.CatId,
                            CategoryName = x.Cat.CatName,
                            IsActive = x.IsActive,
                            BannerImage = x.BannerImage,
                            IconImage = x.IconImage,
                            ShowOnHomePage = x.ShowOnHomePage
                        }).ToList();
                    }
                }
                else if (listFoodType.Count != 0)
                {
                    if (listSubCat.Count != 0)
                    {
                        if (listCat.Count != 0)
                        {
                            listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && listFoodType.Contains(x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                            {
                                FoodId = x.FoodId,
                                FoodName = x.FoodName,
                                FoodDesc = x.FoodDesc,
                                FoodAmount = x.FoodAmount,
                                Quantity = (int)(x.Quantity),
                                FoodTypeId = x.FoodTypeId,
                                FoodTypeName = x.FoodType.FoodType,
                                SubCatId = x.SubCatId,
                                SubCategoryName = x.SubCat.SubCatName,
                                CatId = x.CatId,
                                CategoryName = x.Cat.CatName,
                                IsActive = x.IsActive,
                                BannerImage = x.BannerImage,
                                IconImage = x.IconImage,
                                ShowOnHomePage = x.ShowOnHomePage
                            }).ToList();
                        }
                        else
                        {
                            listFood = _context.TblFoods.Where(x => listFoodType.Contains((int)x.FoodTypeId) && listSubCat.Contains(x.SubCatId) && x.IsActive == true).Select(x => new Food
                            {
                                FoodId = x.FoodId,
                                FoodName = x.FoodName,
                                FoodDesc = x.FoodDesc,
                                FoodAmount = x.FoodAmount,
                                Quantity = (int)(x.Quantity),
                                FoodTypeId = x.FoodTypeId,
                                FoodTypeName = x.FoodType.FoodType,
                                SubCatId = x.SubCatId,
                                SubCategoryName = x.SubCat.SubCatName,
                                CatId = x.CatId,
                                CategoryName = x.Cat.CatName,
                                IsActive = x.IsActive,
                                BannerImage = x.BannerImage,
                                IconImage = x.IconImage,
                                ShowOnHomePage = x.ShowOnHomePage
                            }).ToList();
                        }
                    }
                    else
                    {
                        listFood = _context.TblFoods.Where(x => listFoodType.Contains((int)x.FoodTypeId)  && x.IsActive == true).Select(x => new Food
                        {
                            FoodId = x.FoodId,
                            FoodName = x.FoodName,
                            FoodDesc = x.FoodDesc,
                            FoodAmount = x.FoodAmount,
                            Quantity = (int)(x.Quantity),
                            FoodTypeId = x.FoodTypeId,
                            FoodTypeName = x.FoodType.FoodType,
                            SubCatId = x.SubCatId,
                            SubCategoryName = x.SubCat.SubCatName,
                            CatId = x.CatId,
                            CategoryName = x.Cat.CatName,
                            IsActive = x.IsActive,
                            BannerImage = x.BannerImage,
                            IconImage = x.IconImage,
                            ShowOnHomePage = x.ShowOnHomePage
                        }).ToList();
                    }
                }
                else
                {
                    listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && listFoodType.Contains(x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                    {
                        FoodId = x.FoodId,
                        FoodName = x.FoodName,
                        FoodDesc = x.FoodDesc,
                        FoodAmount = x.FoodAmount,
                        Quantity = (int)(x.Quantity),
                        FoodTypeId = x.FoodTypeId,
                        FoodTypeName = x.FoodType.FoodType,
                        SubCatId = x.SubCatId,
                        SubCategoryName = x.SubCat.SubCatName,
                        CatId = x.CatId,
                        CategoryName = x.Cat.CatName,
                        IsActive = x.IsActive,
                        BannerImage = x.BannerImage,
                        IconImage = x.IconImage,
                        ShowOnHomePage = x.ShowOnHomePage
                    }).ToList();
                }
                //if (listCat.Count==0&& listFoodType.Count!=0)
                //{
                //    if (listSubCat.Count == 0)
                //    {
                //         listFood = _context.TblFoods.Where(x => listFoodType.Contains((int)x.FoodTypeId)  && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                //    else
                //    {
                //        listFood = _context.TblFoods.Where(x => listSubCat.Contains((int)x.SubCatId) && listFoodType.Contains(x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                //}
                //else if (listSubCat.Count == 0&& listFood.Count != 0)
                //{
                //    if (listCat.Count == 0)
                //    {
                //        listFood = _context.TblFoods.Where(x => listFoodType.Contains((int)x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                //    else
                //    {
                //        listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listFoodType.Contains(x.FoodTypeId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                    
                //}
                //else if (listFoodType.Count == 0&&listSubCat.Count!=0)
                //{
                //    if (listCat.Count == 0)
                //    {
                //        listFood = _context.TblFoods.Where(x => listSubCat.Contains((int)x.SubCatId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                //    else
                //    {
                //        listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                    
                // }
                //else if (listCat.Count != 0 && listFoodType.Count == 0) 
                //{
                //    if (listSubCat.Count == 0)
                //    {
                //        listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                //    else
                //    {
                //        listFood = _context.TblFoods.Where(x => listSubCat.Contains((int)x.SubCatId) && listCat.Contains((int)x.CatId) && x.IsActive == true).Select(x => new Food
                //        {
                //            FoodId = x.FoodId,
                //            FoodName = x.FoodName,
                //            FoodDesc = x.FoodDesc,
                //            FoodAmount = x.FoodAmount,
                //            Quantity = (int)(x.Quantity),
                //            FoodTypeId = x.FoodTypeId,
                //            FoodTypeName = x.FoodType.FoodType,
                //            SubCatId = x.SubCatId,
                //            SubCategoryName = x.SubCat.SubCatName,
                //            CatId = x.CatId,
                //            CategoryName = x.Cat.CatName,
                //            IsActive = x.IsActive,
                //            BannerImage = x.BannerImage,
                //            IconImage = x.IconImage,
                //            ShowOnHomePage = x.ShowOnHomePage
                //        }).ToList();
                //    }
                //}
                //else
                //{
                //    listFood = _context.TblFoods.Where(x => listCat.Contains((int)x.CatId) && listSubCat.Contains(x.SubCatId) && listFoodType.Contains(x.FoodTypeId)&& x.IsActive == true).Select(x => new Food
                //    {
                //        FoodId = x.FoodId,
                //        FoodName = x.FoodName,
                //        FoodDesc = x.FoodDesc,
                //        FoodAmount = x.FoodAmount,
                //        Quantity = (int)(x.Quantity),
                //        FoodTypeId = x.FoodTypeId,
                //        FoodTypeName = x.FoodType.FoodType,
                //        SubCatId = x.SubCatId,
                //        SubCategoryName = x.SubCat.SubCatName,
                //        CatId = x.CatId,
                //        CategoryName = x.Cat.CatName,
                //        IsActive = x.IsActive,
                //        BannerImage = x.BannerImage,
                //        IconImage = x.IconImage,
                //        ShowOnHomePage = x.ShowOnHomePage
                //    }).ToList();
                //}

                    return listFood;
                }
        }
        public async Task<Food> GetFoodByID(long id)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
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
                            Quantity = (int)(tbl.Quantity),
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
        public async Task<List<Food>> getFoodsByFoodTypoeID(int foodTypeid)
        {
            using (var _context=new Online_Food_ApplicationContext())
            {
                List<Food> listFood = _context.TblFoods.Where(x => (int)x.FoodTypeId == foodTypeid && x.IsActive == true).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    FoodDesc = x.FoodDesc,
                    FoodAmount = x.FoodAmount,
                    Quantity = (int)(x.Quantity),
                    FoodTypeId = x.FoodTypeId,
                    FoodTypeName = x.FoodType.FoodType,
                    SubCatId = x.SubCatId,
                    SubCategoryName = x.SubCat.SubCatName,
                    CatId = x.CatId,
                    CategoryName = x.Cat.CatName,
                    IsActive = x.IsActive,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage,
                    ShowOnHomePage = x.ShowOnHomePage
                }).ToList();
                return listFood;
            }
                
        }

        public async Task<List<Food>> getFoodsByCategoryID(int Catid)
        {
            using (var _context = new Online_Food_ApplicationContext())
            {
                List<Food> listFood = _context.TblFoods.Where(x => (int)x.CatId == Catid && x.IsActive == true).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    FoodDesc = x.FoodDesc,
                    FoodAmount = x.FoodAmount,
                    Quantity = (int)(x.Quantity),
                    FoodTypeId = x.FoodTypeId,
                    FoodTypeName = x.FoodType.FoodType,
                    SubCatId = x.SubCatId,
                    SubCategoryName = x.SubCat.SubCatName,
                    CatId = x.CatId,
                    CategoryName = x.Cat.CatName,
                    IsActive = x.IsActive,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage,
                    ShowOnHomePage = x.ShowOnHomePage
                }).ToList();
                return listFood;
            }
        }

        public async Task<List<Food>> getFoodsBySubCategoryID(int SubCatid)
        {
            using (var _context = new Online_Food_ApplicationContext())
            {
                List<Food> listFood = _context.TblFoods.Where(x => (int)x.SubCatId == SubCatid && x.IsActive == true).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    FoodDesc = x.FoodDesc,
                    FoodAmount = x.FoodAmount,
                    Quantity = (int)(x.Quantity),
                    FoodTypeId = x.FoodTypeId,
                    FoodTypeName = x.FoodType.FoodType,
                    SubCatId = x.SubCatId,
                    SubCategoryName = x.SubCat.SubCatName,
                    CatId = x.CatId,
                    CategoryName = x.Cat.CatName,
                    IsActive = x.IsActive,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage,
                    ShowOnHomePage = x.ShowOnHomePage
                }).ToList();
                return listFood;
            }
        }
    }
}
