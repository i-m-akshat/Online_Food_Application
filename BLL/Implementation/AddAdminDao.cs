using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;

namespace BLL.Implementation
{
    public class AddAdminDao : AddAdminDAO
    {
        public  async Task<bool> AddAdmin(Admin admin)
        {
            try
            {
                await using(var _context= new Online_Food_ApplicationContext())
                {
                    TblAdmin tbl = new TblAdmin();
                    int AdminID = _context.TblAdmins.Max(x => (int?)x.AdminId) ?? 0;
                    tbl.AdminId = AdminID + 1;
                    tbl.AdminName = admin.AdminName.ToString();
                    tbl.RoleId = Convert.ToInt32(admin.RoleId);
                    tbl.FullAddress = admin.FullAddress.ToString();
                    tbl.FullName = admin.FullName.ToString();   
                    tbl.PhoneNumber = admin.PhoneNumber.ToString();
                    tbl.Image = admin.Image;
                    tbl.IsActive = true;
                    tbl.Password = admin.Password;
                    _context.TblAdmins.Add(tbl);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public  async Task<bool> DeletedAdmin(int id)
        {
            await  using(var _context= new Online_Food_ApplicationContext())
            {
                TblAdmin tbl = await _context.TblAdmins.FindAsync((int)id);
                if (tbl != null)
                {
                   if( tbl.IsActive == false)
                    {
                        tbl.IsActive = true;
                    }
                    else if(tbl.IsActive == true)
                    {
                        tbl.IsActive = false;

                    }else
                        tbl.IsActive = true;
                }
                _context.TblAdmins.Update(tbl);
                _context.SaveChanges();
                return true;
            }
            
        }

        public  async Task<Admin> GetAdmin(int id)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                Admin admin = _context.TblAdmins.Select(x => new Admin
                {
                    AdminId = x.AdminId,
                    AdminName = x.AdminName,
                    Image=x.Image,
                    Password = x.Password,
                    FullAddress = x.FullAddress,
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    IsActive = x.IsActive,
                    RoleId = x.RoleId,
                    RoleName = x.Role.Role
                }).Where(x=>x.AdminId==id).FirstOrDefault();
                return admin;
            }
        }

        public  async Task<List<Admin>> GetAllAdmins()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                return _context.TblAdmins.Select(x => new Admin
                {
                    AdminId = x.AdminId,
                    AdminName = x.AdminName,
                    Image = x.Image,
                    Password = x.Password,
                    FullAddress = x.FullAddress,
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    IsActive = x.IsActive,
                    RoleId = x.RoleId,
                    RoleName = x.Role.Role
                }).ToList();
            }
        }

        public  async Task<List<Role>> GetAllRoles()
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                return _context.TblRoles.Where(x => x.IsActive == true).Select(x => new Role
                {
                    RoleId = x.RoleId,
                    Roles = x.Role
                }).ToList();
            }
        }

        public  async Task<bool> UpdateAdmin(int id, Admin admin)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblAdmin tbl = await _context.TblAdmins.FindAsync((int)id);
                if (tbl != null)
                {
                    tbl.AdminName = admin.AdminName.ToString();
                    tbl.RoleId = Convert.ToInt32(admin.RoleId);
                    tbl.FullAddress = admin.FullAddress.ToString();
                    tbl.FullName = admin.FullName.ToString();
                    tbl.PhoneNumber = admin.PhoneNumber.ToString();
                    if (admin.Image != null)
                    {
                        tbl.Image = admin.Image;
                    }
                    tbl.Password = admin.Password;
                    _context.TblAdmins.Update(tbl);
                    _context.SaveChanges();
                }
                return true;
            }
        }
    }
}
