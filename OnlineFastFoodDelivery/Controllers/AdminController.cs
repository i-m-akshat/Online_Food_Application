using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BLL.Interfaces;
using Models;
using BLL.Implementation;
using OnlineFastFoodDelivery.Utilites;
using Microsoft.AspNetCore.Authorization;
using Models.ViewModel;

namespace OnlineFastFoodDelivery.Controllers
{
    [Route("Admin")]
    
    public class AdminController : Controller
    {
        
         //if we use context in controller then we will use this constructor
        private readonly Online_Food_ApplicationContext _context;
        public AdminController(Online_Food_ApplicationContext _context)
        {
            this._context = _context;
        }


    Admin admin = new Admin();
        AdminLogin DAL = new AdminLoginDao();
        AdminSessionDAO sessionDAL = new AdminSessionDao();
        [Route("")]
        [AllowAnonymous]
        public IActionResult Login()
        {
           return View();
           
        }
        [HttpPost]
        public async Task<IActionResult> Login(string AdminName, string Password)
        {
            
             admin = await DAL.Login(AdminName, Password);
            
            if (admin != null)
            {
                long sessionID = await sessionDAL.CreateSession(admin.AdminId);
                HttpContext.Session.SetInt32("SessionID", (int)sessionID);
                HttpContext.Session.SetString("AdminSession",admin.FullName);
                HttpContext.Session.SetString("AdminRole", admin.RoleName);
                HttpContext.Session.SetInt32("AdminID", admin.AdminId);
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetInt32("UserID") != null)
                {
                    HttpContext.Session.Remove("UserName");
                    HttpContext.Session.Remove("UserID");
                }
                return RedirectToAction("Dashboard");
            }
            else
            {
                TempData["Error"] = "Login Failed!";
                return View();
            }
            

        }
        [HttpGet]
        [Route("Dashboard")]
        //[SessionAuthorize]
        public async  Task<IActionResult> AdminDashboard()
       {
            AdminViewModel _viewModel = new AdminViewModel();
            int AdminID = Convert.ToInt32(HttpContext.Session.GetInt32("AdminID"));
            Admin admin = DAL.getImage(AdminID);
            if (admin.Image != null) { 
                //var AdminImage= Convert.ToBase64String(admin.Image);
             HttpContext.Session.Set("AdminImage",admin.Image);
                _viewModel.count_Orders = await DAL.getCountOrders();
                _viewModel.count_Users=await DAL.getCountUsers();
                _viewModel.count_Admins=await DAL.getCountAdmins();
                _viewModel.sum_earnings = await DAL.getSumEarnings();
                _viewModel.count_Payments = await DAL.getCountPayment();
            }

            return View(_viewModel);
        }
        
        [Route("Logout")]
        public async Task <IActionResult> Logout()
        {
            bool IsSuccess = await sessionDAL.EndSession((long)(HttpContext.Session.GetInt32("SessionID")));
            if (IsSuccess)
            {
                if (HttpContext.Session.GetString("AdminSession").ToString() != null && HttpContext.Session.GetInt32("SessionID").ToString() != null && HttpContext.Session.GetString("AdminRole").ToString() != null)
                {

                    HttpContext.Session.Remove("AdminSession");
                    HttpContext.Session.Remove("SessionID");
                    HttpContext.Session.Remove("AdminRole");
                }
                TempData["Success"] = "Logout SuccessFull";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Logout Failed!";
                return View();
            }
           
            

        }
        [Route("getOrdersPerDate")]
        public async Task<List<OrderGroup>> getOrdersPerDate()
        {
            List<OrderGroup> listOrder = new List<OrderGroup>();
            listOrder = await DAL.ReturnOrdersPerMonth();
            return listOrder;

         }
        [Route("getPaymentPerMonths")]
        public async Task<List<PaymentGroup>> getPaymentPerMonths()
        {
            List<PaymentGroup> listPayment= new List<PaymentGroup>();
            return listPayment= await DAL.ReturnPaymentPerMonth();
        }
        [Route("getAdminPerRoles")]
        public async Task<List<AdminGroup>> getAdminPerRoles()
        {
            List<AdminGroup> listAdmins=new List<AdminGroup>();
            listAdmins = await DAL.GetAdminCountByRoles();
            return listAdmins;
        }
        [Route("getUsersPerAddedDates")]
        public async Task<List<UserGroup>> getUsersPerAddedDates()
        {
            return await DAL.GetUserByDate();
        }

}
}
//Scaffold - DbContext "Server=<ServerName>;Database=<DatabaseName>;User=<Username>;Password=<Password>;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir < ModelOutputDirectory > -ContextDir < DbContextOutputDirectory > -Context<DbContextName>
//Scaffold-DbContext "Server=DESKTOP-RBREH2D\SQLEXPRESS;Database=Online_Food_Application;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "D:\Online Fast Food Delivery project\DAL\Models" -ContextDir "D:\Online Fast Food Delivery project\DAL\Data" -force