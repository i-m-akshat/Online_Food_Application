using BLL.Implementation;
using Microsoft.AspNetCore.Mvc;
using Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFastFoodDelivery.Utilites;

namespace OnlineFastFoodDelivery.Controllers
{
    public class ModeratorController : Controller
    {
        public IFormFile imageFile { get; set; }
        private bool isSuccess = false;
        AddAdminDAO DAL = new AddAdminDao();
        public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        public async Task<IActionResult> Index()
        {
          List<Admin> listAdmin=await DAL.GetAllAdmins();
            return View(listAdmin);
        }
        public async Task<IActionResult> Add_Edit(int? id)
        {
            List<Role> role = await DAL.GetAllRoles();
            if (role != null)
            {
                var ddlRole = role.Select(role => new SelectListItem
                {
                    Text = role.Roles,
                    Value=role.RoleId.ToString()
                });
                ViewBag.Role=ddlRole;
            }
            if (id != null)
            {
                Admin admin =await DAL.GetAdmin((int)id);
                if (admin != null)
                {
                    ViewBag.Action = "Update";
                    return View(admin);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Action = "Add";
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_Edit(int? id,Admin admin)
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                admin.imageFile_Admin= HttpContext.Request.Form.Files[0];
                var extension_Banner = Path.GetExtension(admin.imageFile_Admin.FileName);
                if (ImageExtensions.Contains(extension_Banner.ToUpperInvariant()))
                {
                    NecessaryFunctions nec = new NecessaryFunctions();
                    admin.Image = nec.ImageSave(admin.Image,admin.imageFile_Admin);
                }

            }
            if (id != null)
            {
                isSuccess = await DAL.UpdateAdmin((int)id, admin);
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
                isSuccess = await DAL.AddAdmin(admin);
                if (isSuccess)
                {
                    TempData["Success"] = "Created SuccessFully";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Creation Failed Please try again";

                }
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                isSuccess = await DAL.DeletedAdmin((int)id);
                if (isSuccess)
                {
                    
                    TempData["Success"] = "Admin Status Changed";
                    ModelState.Clear();

                }
                else
                {
                    TempData["Error"] = "Change in status Failed Please try again";

                }
            }
            return RedirectToAction("Index");
        }
    }
}
