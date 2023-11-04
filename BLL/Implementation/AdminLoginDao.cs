using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class AdminLoginDao : AdminLogin
    {
        //public readonly Online_Food_ApplicationContext _context;

        //public AdminLoginDao(Online_Food_ApplicationContext context)
        //{
        //    _context = context;
        //}

        public async Task<Admin> Login(string AdminName, string Password)
        {
            await using (Online_Food_ApplicationContext _context = new Online_Food_ApplicationContext())
            {
                var Admindetails = _context.TblAdmins.Where(x => x.AdminName == AdminName && x.Password == Password && x.IsActive == true).Select(x => new Admin()
                {
                    AdminName = x.AdminName,
                    Password = x.Password,
                    AdminId = x.AdminId,
                    FullName = x.FullName,
                    RoleId = x.RoleId,
                    RoleName = x.Role.Role,
                    Image = x.Image
                }).FirstOrDefault();
                //if (Admindetails.RoleId != null)
                //{
                //    var RoleName=_context.TblAdmins.Role
                //}

                return Admindetails;
            }
        }
        public Admin getImage(int AdminID)
        {
             using (Online_Food_ApplicationContext _context = new Online_Food_ApplicationContext())
            {

                var Admindetails = _context.TblAdmins.Where(x => x.AdminId == AdminID && x.IsActive == true).Select(x => new Admin()
                {
                    AdminName = x.AdminName,
                    Password = x.Password,
                    AdminId = x.AdminId,
                    FullName = x.FullName,
                    RoleId = x.RoleId,
                    RoleName = x.Role.Role,
                    Image = x.Image
                }).FirstOrDefault();
                return Admindetails;
            }
        }
    }
}
