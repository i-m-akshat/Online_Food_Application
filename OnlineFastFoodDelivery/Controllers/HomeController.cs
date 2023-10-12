using Microsoft.AspNetCore.Mvc;
using Models;
using OnlineFastFoodDelivery.Models;
using System.Diagnostics;
using BLL.Interfaces;
using BLL.Implementation;
using Models.ViewModel;

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
            //subCategories = await DAL.GetSubCategoriesForHomePage(int Catid);
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
        public async Task<IActionResult> Foods()
        {
            List<Category> categories = new List<Category>();
            List<Category> topcategories = new List<Category>();
            List<SubCategory> subCategories = new List<SubCategory>();
            List<Food> foods = new List<Food>();
            List<FoodType> foodTypes = new List<FoodType>();
            categories = await DAL.GetAllCategories();
            subCategories = await DAL.GetAllSubCategories(subCategories);
            topcategories = await DAL.GetCategoriesForHomepage();
            foodTypes = await DAL.GetAllFoodTypes();
            foods = await DAL.GetAllFoods();
            var _viewModel = new HomePageViewModel()
            {
                Categories = categories,
                TopCategories = topcategories,
                SubCategories = subCategories,
                Food = foods,
                FoodTypes = foodTypes
            };
            return View(_viewModel);
        }
        public IActionResult FoodDetails()
        {
            return View();
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