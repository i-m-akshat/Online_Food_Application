
using Microsoft.AspNetCore.Mvc;
using OnlineFastFoodDelivery.Models;

namespace OnlineFastFoodDelivery.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        {
            return PartialView("_RecipeCard", recipes);    
        }
    }
}

