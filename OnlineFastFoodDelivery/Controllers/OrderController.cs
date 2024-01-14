using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Implementation;
using Models;
using MailKit;

namespace OnlineFastFoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly SendMailDAO mailService;
        private OrderStatusDAO DAL;
        public OrderController(SendMailDAO _mailService,OrderStatusDAO _orderServices) 
        {
            this.mailService = _mailService;
            this.DAL= _orderServices;  
        }

       
        //OrderStatusDAO DAL=new OrderStatusDao();
        public async Task<IActionResult> Index()
        {
            orderModel listorder=await DAL.GetAllOrders(1);
            if (listorder != null)
            {
                return View(listorder);
            }else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(int CurrentPageIndex)
        {
            orderModel listorder = await DAL.GetAllOrders(CurrentPageIndex);
            if (listorder != null)
            {
                return View(listorder);
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Deliver(int Id)
        {
            bool IsSuccess = await DAL.Delivered(Id);
            if (IsSuccess)
            {
                string Email = await DAL.GetEmailbyOrderID(Id);
                bool res = await SendEmailNotifications("has been Delivered", Email);
                if (res)
                {
                    TempData["Success"] = "Order Status Changed";
                }
                
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
            bool IsSuccess = await DAL.InTransit(id);
            if (IsSuccess)
            {
                string Email = await DAL.GetEmailbyOrderID(id);
                bool res = await SendEmailNotifications("is In Transit", Email);
                if (res)
                {
                    TempData["Success"] = "Order Status Changed";
                }
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
            bool IsSuccess = await DAL.Waiting(id);
            if (IsSuccess)
            {
                string Email = await DAL.GetEmailbyOrderID(id);
                bool res = await SendEmailNotifications("is Waiting To be Picked Up by Courier Partner", Email);
                if (res)
                {
                    TempData["Success"] = "Order Status Changed";
                }
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
            bool IsSuccess=await DAL.Cancel(id);
            if (IsSuccess)
            {
                string Email = await DAL.GetEmailbyOrderID(id);
                bool res = await SendEmailNotifications("has been Cancelled", Email);
                if (res)
                {
                    TempData["Success"] = "Order Status Changed";
                }
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
            bool IsSuccess = await DAL.OutForDelivery(id);
            if (IsSuccess)
            {
                string Email = await DAL.GetEmailbyOrderID(id);
                bool res = await SendEmailNotifications("is Out For Delivery", Email);
                if (res)
                {
                    TempData["Success"] = "Order Status Changed";
                }
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
            bool IsSuccess = await DAL.PickedByDeliveryPerson(id);
            if (IsSuccess)
            {
                string Email = await DAL.GetEmailbyOrderID(id);
                bool res = await SendEmailNotifications("has been Picked Up By Courier Partner", Email);
                if (res)
                {
                    TempData["Success"] = "Order Status Changed";
                }
                ModelState.Clear();

            }
            else
            {
                TempData["Error"] = "Failed ! Please Try Again";

            }
            return RedirectToAction("Index");
        }
        public async Task<bool> SendEmailNotifications(string Message, string EmailID)
        {
            bool isSuccess = false;
            Email emailMessage = new Email();
            emailMessage.ToEmail = EmailID;
            emailMessage.Subject = string.Format("RE: Order Status Changed");
            emailMessage.Body = string.Format("Hey User!,<br/><br/> Your Order Status has been changed, Your order  <b>{0}</b>.<br/><br/><hr/>Thank Your For Ordering with Us", Message);
            isSuccess= await mailService.SendMailAsync(emailMessage);
            if (isSuccess)
            {

                return true;

            }
            else
            {

                return false;
            }
        }
        
    }
}
