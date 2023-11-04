using Microsoft.AspNetCore.Mvc;
using Models;
using OnlineFastFoodDelivery.Models;
using System.Diagnostics;
using BLL.Interfaces;
using BLL.Implementation;
using Models.ViewModel;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery.Controllers
{
    
    public class HomeController : Controller
    {
        HomePageDAO DAL = new HomePageDao();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            List<Category> categories=new List<Category>();
            List<Category> topcategories = new List<Category>();
            List<SubCategory> subCategories=new List<SubCategory>();
            List<Food> foods = new List<Food>();
            List<FoodType> foodTypes = new List<FoodType>();
            categories = await DAL.GetAllCategories();
            topcategories = await DAL.GetCategoriesForHomepage() ;
            foodTypes = await DAL.GetAllFoodTypes();
            subCategories = await DAL.GetSubCategoriesForHomePage();
            foods = await DAL.GetFoodsForHomepage();
            var _viewModel = new HomePageViewModel()
            {
                Categories = categories,
                TopCategories=topcategories,
                SubCategories=subCategories,
                Food=foods,
                FoodTypes=foodTypes
            };
            return View(_viewModel);
        }
        [Route("Foods")]
        public async Task<IActionResult> Foods(int? FoodTypeID, int? CatID, int? SubCatID)
        {

            HomePageViewModel _viewModel = new HomePageViewModel();
            List<Category> categories = new List<Category>();
            List<Category> topcategories = new List<Category>();
            List<SubCategory> subCategories = new List<SubCategory>();
            List<Food> foods = new List<Food>();
            List<FoodType> foodTypes = new List<FoodType>();
            if ( FoodTypeID != null)
            {
                foods =await DAL.getFoodsByFoodTypoeID((int)FoodTypeID);
            }
            else if(CatID != null)
            {
                foods =await DAL.getFoodsByCategoryID((int)CatID);
            }
            else if( SubCatID != null)
            {
                foods = await DAL.getFoodsBySubCategoryID((int)SubCatID);
            }
            else
            {
                foods = await DAL.GetAllFoods();
            }
                categories = await DAL.GetAllCategories();
                subCategories = await DAL.GetAllSubCategories(subCategories);
                topcategories = await DAL.GetCategoriesForHomepage();
                foodTypes = await DAL.GetAllFoodTypes();
                //foods = await DAL.GetAllFoods();

                _viewModel = new HomePageViewModel()
                {
                    Categories = categories,
                    TopCategories = topcategories,
                    SubCategories = subCategories,
                    Food = foods,
                    FoodTypes = foodTypes
                };
                return View(_viewModel);
         
        }
        public async Task<IActionResult> Filter(List<int>? listCat,List<int>? listSubCat,List<int>? listFoodType)
        {
            
            List<Food> listFood = new List<Food>();
            HomePageViewModel _viewModel = new HomePageViewModel();
            listFood = await DAL.GetAllFoods_Filter(listCat, listSubCat, listFoodType);
            
           

            return PartialView("_Food",listFood);

            
        }
        
        public async Task<IActionResult> FoodDetails(int FoodID)
        {
            Food model = new Food();
            model = await DAL.GetFoodByID(FoodID);
            return View(model);
        }
        public async Task<IActionResult> UserProfile(int id)
        {
            try
            {
                User user = new User();
                user = await DAL.GetUserDetails(id);
                return View(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<List<SubCategory>> getSubCategoryBasedOnCat(List<int> list)
        {
            
            List<SubCategory> listSub = await DAL.GetSubCategoriesForHomePage(list);
            
            return listSub;
        }
       
        public IActionResult Logout()
        {

            if (HttpContext.Session.GetString("AdminSession").ToString() != null)
            {
                HttpContext.Session.Remove("AdminSession");
            }
            return View("Index");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}