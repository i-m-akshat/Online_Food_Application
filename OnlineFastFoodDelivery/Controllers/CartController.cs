using Microsoft.AspNetCore.Mvc;
using Models;
using BLL.Interfaces;
using BLL.Implementation;

namespace OnlineFastFoodDelivery.Controllers
{
    public class CartController : Controller
    {
        CartDAO DAL = new CartDao();
        public async Task<IActionResult> Index()
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            if (UserID.HasValue)
            {
                List<Cart> listCart = new List<Cart>();
                listCart = await DAL.GetAllItems((int)UserID);
                ViewBag.SubTotal = await DAL.GetOverallPrice((int)UserID);
                return View(listCart);
            }
            else
            {
                TempData["Error"] = "Please Login";
                return RedirectToAction("UserLogin", "User");
            }
        }
        public async Task<IActionResult> AddToCart(int FoodID,int Quantity=1)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            if (UserID.HasValue)
            {
                if (FoodID != null || FoodID != 0)
                {
                    
                    bool isExist =await DAL.CheckIfExist(FoodID, (int)UserID);
                    if (isExist)
                    {
                        bool isSuccess = await DAL.AddToExisting(FoodID,(int)UserID);
                        if (isSuccess)
                        {
                            CartDAO cartDAL = new CartDao();
                            int CartNumber = await cartDAL.GetTotalNumberOFItemsInCart((int)UserID);
                            if (CartNumber != 0)
                            {
                                HttpContext.Session.SetInt32("CartNumber", (int)CartNumber);
                            }
                            TempData["Success"] = "Item Quantity Increased";
                            return RedirectToAction("Index", "Cart");
                        }
                        else
                        {
                            TempData["Error"] = "Something went wrong";
                            return View();
                        }
                    }
                    else
                    {
                        Cart cart = new Cart();
                        cart.Quantity = Quantity;
                        cart.FoodId = FoodID;
                        cart.UserId = (int)UserID;
                        bool isSuccess = await DAL.AddtoCart(cart);
                        if (isSuccess)
                        {
                            CartDAO cartDAL = new CartDao();
                            int CartNumber = await cartDAL.GetTotalNumberOFItemsInCart((int)UserID);
                            if (CartNumber != 0)
                            {
                                HttpContext.Session.SetInt32("CartNumber", (int)CartNumber);
                            }
                            TempData["Success"] = "Item Added To Cart Successfully";
                            return RedirectToAction("Index", "Cart");
                          
                        }
                        else
                        {
                            TempData["Error"] = "Something went wrong";
                            return View();
                        }
                        
                    }
                    
                }
                else
                {
                    TempData["Error"] = "Something went wrong";
                    return View();
                }
            }
            else
            {
                TempData["Error"] = "Please Login";
                return RedirectToAction("UserLogin","User");
            }


        }
        [HttpGet]
        public async Task<IActionResult> RemoveItem(int ItemID)
        {
            if (ItemID != 0 || ItemID != null)
            {
                int? UserID = HttpContext.Session.GetInt32("UserID");
                bool isSuccess = await DAL.DeleteItems(ItemID, (int)UserID);
                if (isSuccess)
                {
                    CartDAO cartDAL = new CartDao();
                    int CartNumber = await cartDAL.GetTotalNumberOFItemsInCart((int)UserID);
                    if (CartNumber == 0)
                    {
                        HttpContext.Session.Remove("CartNumber");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("CartNumber", (int)CartNumber);
                    }
                    TempData["Success"] = "Item Removed From the Cart";
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    TempData["Error"] = "Something Goes Wrong!";
                    return View("Index");
                }

            }
            else
            {
                TempData["Error"] = "Something Goes Wrong!";
                return View("Index");
            }
        }
        public async Task<IActionResult> IncreaseQuantity(int FoodID)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            if (UserID.HasValue)
            {
                
                int i = await DAL.increaseQuantity(FoodID,(int)UserID);
                if (i != 0)
                {
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong!";
                    return View("Index");
                }
            }
            else
            {
                TempData["Error"] = "Please Login";
                return RedirectToAction("UserLogin", "User");
            }
        }
        public async Task<IActionResult> DecreaseQuantity(int FoodID)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            if (UserID.HasValue)
            {
                
                int i  = await DAL.decreaseQuantity(FoodID,(int)UserID);
                if (i != 0)
                {
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong!";
                    return View("Index");
                }
            }
            else
            {
                TempData["Error"] = "Please Login";
                return RedirectToAction("UserLogin", "User");
            }
        }
    }
}
