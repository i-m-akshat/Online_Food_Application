
using BLL.Implementation;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using OnlineFastFoodDelivery.Utilites;

namespace OnlineFastFoodDelivery.Controllers
{
    public class FoodController : Controller
    {
        NecessaryFunctions nec = new NecessaryFunctions();
        public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        public IFormFile imageFile { get; set; }
        bool isSuccess=false;
        FoodDAO DAL = new FoodDao();
        public async Task<IActionResult> Index()
        {
            List<Food> list = new List<Food>();
            list = await DAL.GetAllFoodList();
            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View();  
            }
        }
        public async Task<IActionResult> Add_Edit(int? id)
        {
            var _catOptions = await DAL.GetAllCategories();
            if (_catOptions != null)
            {
                var ddlCat = _catOptions.Select(_catOptions => new SelectListItem
                {
                    Text = _catOptions.CategoryName.ToString(),
                    Value = _catOptions.CatId.ToString()
                });
                ViewBag.Categories = ddlCat;
            var _subCatOptions= await DAL.GetAllSubCategories();
                if(_subCatOptions != null)
                {
                    var ddlSub = _subCatOptions.Select(_subCatOptions => new SelectListItem
                    {
                        Text = _subCatOptions.SubCategoryName.ToString(),
                        Value = _subCatOptions.SubCatId.ToString()
                    });
                    ViewBag.SubCategories = ddlSub;
                }
                var _FoodTypeOptions = await DAL.GetAllFoodType();
                if (_FoodTypeOptions != null) 
                {

                    var ddlFoodList = _FoodTypeOptions.Select(_FoodTypeOptions => new SelectListItem
                    {
                        Text = _FoodTypeOptions.FoodTypeName.ToString(),
                        Value = _FoodTypeOptions.FoodTypeId.ToString()
                    });
                    ViewBag.FoodType = ddlFoodList; 
                }

            }
            if (id != null)
            {
                Food food = await DAL.GetFoodByID((int)id);
                return View(food);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_Edit(int? id, Food food)
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                food.imageFile_Icon = HttpContext.Request.Form.Files[0];
                food.imageFile_Banner = HttpContext.Request.Form.Files[1]; 
                var extension_Banner = Path.GetExtension(food.imageFile_Banner.FileName);
                var extension_Icon = Path.GetExtension(food.imageFile_Icon.FileName);
                if (ImageExtensions.Contains(extension_Banner.ToUpperInvariant()) && ImageExtensions.Contains(extension_Icon.ToUpperInvariant()))
                {
                    food.BannerImage = nec.ImageSave(food.BannerImage, food.imageFile_Banner);
                    food.IconImage = nec.ImageSave(food.IconImage, food.imageFile_Icon);
                }
            }
            if (id != null) 
            {
                food.UpdatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess = await DAL.UpdateFood((long)id, food);
                if (isSuccess)
                {
                    TempData["Success"] = "Updated SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Updation Failed Please try again";

                }
            }
            else
            {
                food.CreatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess = await DAL.InsertFood(food);
                if (isSuccess)
                {
                    TempData["Success"] = "Created SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Creation Failed Please try again";

                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(int? id,Food food)
        {
            food.DeletedBy = null;
            if (id != null)
            {
                food.DeletedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess = await DAL.DeleteFood((int)id, food);
                if (isSuccess)
                {
                    TempData["Success"] = "Deleted SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Deletion Failed Please try again";

                }
            }
            return RedirectToAction("Index");   
        }
    }
}
