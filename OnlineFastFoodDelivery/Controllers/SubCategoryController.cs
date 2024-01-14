using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;
using BLL.Interfaces;
using BLL.Implementation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFastFoodDelivery.Utilites;

namespace OnlineFastFoodDelivery.Controllers
{
    public class SubCategoryController : Controller
    {
        public static readonly List<string> ImageExtensions= new() { ".JPG", ".BMP", ".PNG" };
        public IFormFile imageFile { get; set; }
        SubCategoryDAO DAL = new SubCategoryDao();
        bool isSuccess=false;
        public async Task<IActionResult> Index()
        {
            Authorize("Admin");
            SubcategoryModel _subCat = new SubcategoryModel();
            _subCat = await DAL.GetAllSubCategories(1);
            return View(_subCat);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int CurrentPageIndex)
        {
            Authorize("Admin");
            SubcategoryModel _subCat = new SubcategoryModel();
            _subCat = await DAL.GetAllSubCategories(CurrentPageIndex);
            return View(_subCat);
        }
        public async Task<IActionResult> Add_Edit(int? id)
        {
            Authorize("Admin");
            var Options = await DAL.GetCategoriesForDropdownList();
            var dropDownOptions=Options.Select(option=>new SelectListItem
            {
                Text= option.CatName,
                Value=option.CatId.ToString()
            });
            ViewBag.Categories = dropDownOptions;
            if (id == null)
            {
                ViewBag.Action ="Create";
                return View();
            }
            else
            {
                SubCategory subCat = new SubCategory();
                subCat= await DAL.GetSubCategoryById(id, subCat);
                ViewBag.Action = "Update";
                return View(subCat);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Add_Edit(int? id, SubCategory subcat)
        {
            if (HttpContext.Request.Form.Files.Count > 0) 
            {
                NecessaryFunctions nec = new NecessaryFunctions();
                if (HttpContext.Request.Form.Files.Count == 1)
                {
                    if (subcat.imageFile_Banner != null)
                    {
                        subcat.imageFile_Banner = HttpContext.Request.Form.Files[0];
                        var extension_Banner = Path.GetExtension(subcat.imageFile_Banner.FileName);

                        if (ImageExtensions.Contains(extension_Banner.ToUpperInvariant()))
                        {
                            subcat.BannerImg = nec.ImageSave(subcat.BannerImg, subcat.imageFile_Banner);

                        }
                    }
                    else if (subcat.imageFile_Icon != null)
                    {
                        subcat.imageFile_Icon = HttpContext.Request.Form.Files[0];
                        var extension_Icon = Path.GetExtension(subcat.imageFile_Icon.FileName);
                        if (ImageExtensions.Contains(extension_Icon.ToUpperInvariant()))
                        {
                            subcat.IconImg = nec.ImageSave(subcat.IconImg, subcat.imageFile_Icon);
                        }
                    }
                }
                else
                {
                    subcat.imageFile_Banner = HttpContext.Request.Form.Files[0];
                    subcat.imageFile_Icon = HttpContext.Request.Form.Files[1];
                    var extension_Banner = Path.GetExtension(subcat.imageFile_Banner.FileName);
                    var extension_Icon = Path.GetExtension(subcat.imageFile_Icon.FileName);
                    if (ImageExtensions.Contains(extension_Banner.ToUpperInvariant()) && ImageExtensions.Contains(extension_Icon.ToUpperInvariant()))
                    {
                        subcat.BannerImg = nec.ImageSave(subcat.BannerImg, subcat.imageFile_Banner);
                        subcat.IconImg = nec.ImageSave(subcat.IconImg, subcat.imageFile_Icon);
                    }
                }
            }
            
            if (id == null)
            {
                subcat.CreatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess =await DAL.InsertSubCategory(subcat);
                if (isSuccess)
                {
                    TempData["Success"] = "Sub Category Created";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Creation Failed Please validate all the fields and try again";

                }
            }
            else
            {
                subcat.UpdatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess = await DAL.UpdateSubCategory((int)id, subcat);
                if (isSuccess)
                {
                    TempData["Success"] = "Sub Category Updated";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Updation Failed Please validate all the fields and try again";

                }
            }
            
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            Authorize("Admin");
            if (id != 0 || id != null)
            {
                SubCategory subCat = new SubCategory
                {
                    DeletedBy = (long)(HttpContext.Session.GetInt32("SessionID"))
                };
                isSuccess = await DAL.DeleteSubCategory(id, subCat);
            }
            if (isSuccess)
            {
                TempData["Success"] = "Sub Category Deleted";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Error"] = "Deletion Failed Please  try again";
               
            }
            return RedirectToAction("Index");
        }
        public void Authorize(string RoleName)
        {
            if (HttpContext.Session.GetString("RoleName") != RoleName)
            {
                RedirectToAction("Dashboard", "Admin");
            }
        }
    }
}
