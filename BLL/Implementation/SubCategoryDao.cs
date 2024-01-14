using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class SubCategoryDao : SubCategoryDAO
    {
        public async Task<bool> DeleteSubCategory(int id, SubCategory subCat)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                   TblSubCategory tbl= await _context.TblSubCategories.FindAsync((int)id);

                    if (tbl != null) 
                    {
                        tbl.IsActive = false;
                        tbl.DeletedDate = Convert.ToDateTime(DateTime.Now.Date);
                        tbl.DeletedBy = subCat.DeletedBy;
                        _context.TblSubCategories.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                  
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<SubcategoryModel> GetAllSubCategories(int CurrentPage)
        {
            try
            {
                int maxRows = 5;
                SubcategoryModel _subCatModel=new SubcategoryModel();
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    _subCatModel.subcategories = _context.TblSubCategories.Where(x => x.IsActive == true&&x.Cat.IsActive==true).Select(x => new SubCategory()
                    {
                        SubCatid = x.SubCatid,
                        SubCatName = x.SubCatName,
                        SubCatDescription = x.SubCatDescription,
                        BannerImg = x.BannerImg,
                        IconImg = x.IconImg,
                        CatId = (short)(x.CatId),
                        CatName=x.Cat.CatName,
                    }).OrderBy(x => x.SubCatid).Skip((CurrentPage - 1) * maxRows).Take(maxRows).ToList();
                    double Pagecount = (double)((decimal)_context.TblSubCategories.Where(x => x.IsActive == true && x.Cat.IsActive == true).Count() / Convert.ToDecimal(maxRows));
                    _subCatModel.PageCount = (int)Math.Ceiling(Pagecount);
                    _subCatModel.CurrentPageIndex = CurrentPage;
                    return _subCatModel;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SubCategory> GetSubCategoryById(int? id, SubCategory subCat)
        {
            try
            {
                await using(var _context= new Online_Food_ApplicationContext())
                {
                    subCat = _context.TblSubCategories.Where(x => x.SubCatid == id).Select(x => new SubCategory()
                    {
                        SubCatid = x.SubCatid,
                        SubCatName = x.SubCatName,
                        SubCatDescription = x.SubCatDescription,
                        BannerImg = x.BannerImg,
                        IconImg = x.IconImg,
                        CatId = (short)(x.CatId)
                    }).FirstOrDefault();
                    return subCat;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> InsertSubCategory(SubCategory subCat)
        {
            try
            {
                await using ( var _context =new Online_Food_ApplicationContext())
                {
                    int SubCategoryID = _context.TblSubCategories.Max(x => (int?)x.SubCatid) ??0;
                    TblSubCategory tbl = new TblSubCategory();
                    tbl.SubCatid = (int)(SubCategoryID+1);
                    tbl.SubCatName = subCat.SubCatName;
                    tbl.SubCatDescription=subCat.SubCatDescription;
                    tbl.CatId = subCat.CatId;
                    tbl.IsActive = true;
                    tbl.BannerImg = subCat.BannerImg;
                    tbl.IconImg=subCat.IconImg;
                    tbl.CreatedBy = subCat.CreatedBy;
                    tbl.CreatedDate = Convert.ToDateTime(DateTime.Now.Date);
                    _context.TblSubCategories.Add(tbl);
                    _context.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSubCategory(int id, SubCategory subCat)
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    TblSubCategory tbl = await _context.TblSubCategories.FindAsync((int)(id));
                    if (tbl != null)
                    {
                        tbl.SubCatName=subCat.SubCatName;
                        tbl.SubCatDescription= subCat.SubCatDescription;
                        if (subCat.BannerImg != null)
                        {
                            tbl.BannerImg = subCat.BannerImg;
                        }
                        if(subCat.IconImg!=null)
                        {
                            tbl.IconImg = subCat.IconImg;
                        }
                        tbl.UpdatedBy = subCat.UpdatedBy;
                        tbl.UpdatedDate = Convert.ToDateTime(DateTime.Now.Date);
                        tbl.CatId = subCat.CatId;
                        _context.TblSubCategories.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<SubCategory>> GetCategoriesForDropdownList()
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                List<SubCategory> subCategories = new List<SubCategory>();
                subCategories = await _context.TblCategories.Where(x => x.IsActive == true).Select(x => new SubCategory()
                {
                    CatId = x.CatId,
                    CatName = x.CatName

                }).ToListAsync();
                return subCategories;
            }
        }
    }
}
