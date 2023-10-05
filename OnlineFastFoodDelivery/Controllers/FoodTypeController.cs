using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;
using BLL.Interfaces;
using BLL.Implementation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFastFoodDelivery.Utilites;

namespace OnlineFastFoodDelivery.Controllers
{
    public class FoodTypeController : Controller
    {
        public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        public IFormFile imageFile { get; set; }
        FoodTypeDAO DAL = new FoodTypeDao();
        bool IsSuccess = false;
        public async Task<IActionResult> Index()
        {
            try
            {
                List<FoodType> listFoodType = new List<FoodType>();
                listFoodType =await DAL.GetAllFoodTypes();
                if (listFoodType != null)
                {
                    return View(listFoodType);
                }
                else { return View(); }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<IActionResult> Add_Edit(int? id)
        {
           
            var subCategories= await DAL.getAllSubCategoriesForDropdown();
            var ddlListSub = subCategories.Select(subCategories => new SelectListItem
            {
                Value = subCategories.SubCatid.ToString(),
                Text = subCategories.SubCategoryName
            });
            ViewBag.SubCategories=ddlListSub;
            var Categories=await DAL.getAllCategoriesForDropdown();
            var ddlListCat = Categories.Select(Categories => new SelectListItem
            {
                Text = Categories.CategoryName,
                Value = Categories.CatId.ToString()
            });
            ViewBag.Categories=ddlListCat;
            if (id != null)
            {
                FoodType foodType =await DAL.GetFoodTypeById((int)id);
                ViewBag.Action = "Update";
                return View(foodType);
                
            }
            else
            {
                ViewBag.Action = "Create";
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Add_Edit(int? id,FoodType foodType)
        {
            try
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    NecessaryFunctions nec = new NecessaryFunctions();
                    foodType.ImageFile_FoodType = HttpContext.Request.Form.Files[0];
                    var extension_file = Path.GetExtension(foodType.ImageFile_FoodType.FileName);
                    if (ImageExtensions.Contains(extension_file.ToUpperInvariant()))
                    {
                        foodType.FoodTypeImg = nec.ImageSave(foodType.FoodTypeImg, foodType.ImageFile_FoodType);
                    }
                }
                if (id == null)
                {
                    foodType.CreatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                    IsSuccess = await DAL.InsertFoodType( foodType);
                    if (IsSuccess)
                    {
                        TempData["Success"] = "Food Type Created";
                        ModelState.Clear();

                    }
                    else
                    {
                        TempData["Error"] = "Creation Failed Please validate all the fields and try again";

                    }
                    return View();
                }
                else
                {
                    foodType.UpdatedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                    IsSuccess =await DAL.UpdateFoodType((int)id, foodType);
                    if (IsSuccess)
                    {
                        TempData["Success"] = "Food Type Updated";
                        ModelState.Clear();

                    }
                    else
                    {
                        TempData["Error"] = "Updation Failed Please validate all the fields and try again";

                    }
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            FoodType foodType =new FoodType();
            foodType.DeletedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
            IsSuccess = await DAL.DeleteFoodType((int)id,foodType);
            if (IsSuccess)
            {
                TempData["Success"] = "Deleted SuccessFully";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Deletion Failed Please try again";

            }
            return RedirectToAction("Index");

        }
    }
}
