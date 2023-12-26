using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Implementation;
using Models;

namespace OnlineFastFoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        OrderStatusDAO DAL=new OrderStatusDao();
        public async Task<IActionResult> Index()
        {
            List<Order> listorder=await DAL.GetAllOrders();
            if (listorder != null)
            {
                return View(listorder);
            }else
            {
                return View();
            }
        }
        public async Task<IActionResult> Deliver(int Id)
        {
            bool isSuccess = await DAL.Delivered(Id);
            if (isSuccess)
            {
                TempData["Success"] = "Order Status Changed";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> InTransit(int id)
        {
            bool isSuccess = await DAL.InTransit(id);
            if (isSuccess)
            {
                TempData["Success"] = "Order Status Changed";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Waiting(int id)
        {
            bool isSuccess = await DAL.Waiting(id);
            if (isSuccess)
            {
                TempData["Success"] = "Order Status Changed";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Cancelled(int id)
        {
            bool isSuccess=await DAL.Cancel(id);
            if (isSuccess)
            {
                TempData["Success"] = "Order Cancelled";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");  
        }
        public async Task<IActionResult> OutForDelivery(int id)
        {
            bool isSuccess = await DAL.OutForDelivery(id);
            if (isSuccess)
            {
                TempData["Success"] = "Order Status Changed";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Picked(int id)
        {
            bool isSuccess = await DAL.PickedByDeliveryPerson(id);
            if (isSuccess)
            {
                TempData["Success"] = "Order Status Changed";
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");
        }
    }
}
