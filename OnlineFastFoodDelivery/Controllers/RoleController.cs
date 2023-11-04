using Microsoft.AspNetCore.Mvc;
using Models;
using OnlineFastFoodDelivery.Utilites;
using BLL.Implementation;
using BLL.Interfaces;

namespace OnlineFastFoodDelivery.Controllers
{
    
    public class RoleController : Controller
    {
        bool isSuccess=false;
        RolesDAO DAL = new RolesDao();
        public async Task<IActionResult> Index()
        {
            List<Role> roles= new List<Role>();
            roles = await DAL.GetAllRoles();
            if(roles!=null)
                return View(roles);
            else return View();
        }
        public async Task<IActionResult> Add_Edit(int? id)
        {
            if (id != null)
            {
                Role role = await DAL.GetRoleByID((int)id);
                ViewBag.Action = "Update";
                if (role != null)
                
                    return View(role);
                
                else
               
                    return View();
               
            }
            else
            {
                ViewBag.Action = "Create";
                return View();  
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_Edit(int? id, Role role)
        {
            if (id != null) 
            {
                role.CreatedBy= (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess =await DAL.UpdateRoles((int)id, role);
                if (isSuccess)
                {
                    TempData["Success"] = "Updated SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Updation Failed Please try again";

                }
            }
            else
            {
                role.UpdatedBy= (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess =await DAL.AddRoles(role);
                if (isSuccess)
                {
                    TempData["Success"] = "Role Added SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Failed Please Check all the Fields and try again";

                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(int? id,Role role)
        {
            if (id != null) 
            {
                role.DeletedBy = (long)(HttpContext.Session.GetInt32("SessionID"));
                isSuccess = await DAL.RemoveRoles((int)id, role);
                if (isSuccess)
                {
                    TempData["Success"] = "Deleted SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Deletion Failed Please try again";

                }
            }
            return RedirectToAction("Index");
        }
    }
}
