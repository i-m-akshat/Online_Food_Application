using BLL.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery.Utilites;
using NuGet.Versioning;

namespace OnlineFastFoodDelivery.Controllers
{
    public class CategoryController : Controller
    {
        public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        public IFormFile imageFile { get; set; }
        CategoryDAO DAL = new CategoryDao();



        public async Task<IActionResult> Index()
        {
            Authorize("Admin");
            CategoryModel _catModel = new CategoryModel();
            _catModel = await DAL.GetAllCategories(1);
            ViewData["categories"] = _catModel.categories;
            return View(_catModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int CurrentPageIndex)
        {
            Authorize("Admin");
            CategoryModel _catModel = new CategoryModel();
            _catModel = await DAL.GetAllCategories(CurrentPageIndex);
            ViewData["categories"] = _catModel.categories;
            return View(_catModel);
        }

        public async Task<IActionResult> Add_Edit(int? id)
        {
            Authorize("Admin");
            if (id != null)
            {
                Category category = await DAL.GetCategoryDetails(id);
                ViewBag.Action = "Edit";
                return View(category);
            }
            else
            {
                ViewBag.Action = "Create";
                return View();
            }


        }
        [HttpPost]
        public async Task<IActionResult> Add_Edit(int? id, Category category)
        {

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                NecessaryFunctions nec = new NecessaryFunctions();
                if (HttpContext.Request.Form.Files.Count == 1)
                {
                    if (category.imageFile_Banner != null)
                    {
                        category.imageFile_Banner = HttpContext.Request.Form.Files[0];
                        var extension_Banner = Path.GetExtension(category.imageFile_Banner.FileName);

                        if (ImageExtensions.Contains(extension_Banner.ToUpperInvariant()))
                        {
                            category.BannerImage = nec.ImageSave(category.BannerImage, category.imageFile_Banner);

                        }
                    }
                    else if (category.imageFile_Icon != null)
                    {
                        category.imageFile_Icon = HttpContext.Request.Form.Files[0];
                        var extension_Icon = Path.GetExtension(category.imageFile_Icon.FileName);
                        if (ImageExtensions.Contains(extension_Icon.ToUpperInvariant()))
                        {

                            category.IconImage = nec.ImageSave(category.IconImage, category.imageFile_Icon);
                        }
                    }
                }
                else
                {
                    category.imageFile_Banner = HttpContext.Request.Form.Files[0];
                    category.imageFile_Icon = HttpContext.Request.Form.Files[1];
                    var extension_Banner = Path.GetExtension(category.imageFile_Banner.FileName);
                    var extension_Icon = Path.GetExtension(category.imageFile_Icon.FileName);
                    if (ImageExtensions.Contains(extension_Banner.ToUpperInvariant()) && ImageExtensions.Contains(extension_Icon.ToUpperInvariant()))
                    {
                        category.BannerImage = nec.ImageSave(category.BannerImage, category.imageFile_Banner);
                        category.IconImage = nec.ImageSave(category.IconImage, category.imageFile_Icon);
                    }
                }
            }
            if (id != null)
            {
                category.UpdatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                bool isSuccess = await DAL.UpdateCategoryDetails((int)id, category);
                if (isSuccess)
                {
                    TempData["Success"] = "Category Updated";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = " Updation Failed Please validate all the fields and try again";

                }
            }
            else if (id == null)
            {
                category.CreatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                bool isSuccess = await DAL.InsertCategory(category);
                if (isSuccess)
                {
                    TempData["Success"] = "Category Created";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Creation Failed Please validate all the fields and try again";

                }

            }
            return View();
        }


        public async Task<IActionResult> DeleteAsync(int id)
        {
            Authorize("Admin");
            bool isSuccess = false;
            if (id != 0 || id != null)
            {
                Category category = new Category();
                category.DeletedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess = await DAL.DeleteCategoryDetails(id, category);
            }
            if (isSuccess)
            {
                TempData["Success"] = "Category Deleted";
                //ModelState.Clear();

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
