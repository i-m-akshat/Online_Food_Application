using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineFastFoodDelivery.Utilites
{
    //Here we are creating a custom attribute for validating our Admin session if there is a value then it will let it pass otherwise throw the 
    //user to login page
    public class SessionAuthorize : Attribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var result = context.HttpContext.Session.GetString("AdminSession");
            if (result == null)
            {
                context.Result = new RedirectToActionResult("Login", "Admin", null);
            }
        }
    }
}
