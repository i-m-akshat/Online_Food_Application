using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace OnlineFastFoodDelivery.Controllers
{
    public class ChatGPTController : Controller
    {
        private readonly IADProductService _productService;
        public ChatGPTController(IADProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<ChatGptResponseModel>> generateResponse([FromBody]CustomerRequestModel generateRequestModel)
        {
            try
            {
                var response = await _productService.GenerateAdContent(generateRequestModel);
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
