using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class RolesDao : RolesDAO
    {
        public async Task<bool> AddRoles(Role role)
        {
            try
            {
                await using ( var _context=new Online_Food_ApplicationContext())
                {
                    int RoleID = _context.TblRoles.Max(x => (int?)x.RoleId) ?? 0;
                    TblRole tbl = new TblRole();
                    tbl.RoleId = RoleID + 1;
                    tbl.Role = role.Roles.ToString();
                    tbl.CreatedDate = DateTime.Now;
                    tbl.CreatedBy = role.CreatedBy;
                    tbl.IsActive = true;
                    _context.TblRoles.Add(tbl);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            await using(var _context= new Online_Food_ApplicationContext())
            {
                List<Role> roles= new List<Role>();
                roles = _context.TblRoles.Where(x => x.IsActive == true).Select(x => new Role
                {
                    RoleId = x.RoleId,
                    Roles = x.Role,
                    IsActive = x.IsActive
                }).ToList();
                return roles;
            }
        }

        public async Task<Role> GetRoleByID(int id)
        {
            try
            {
                await using(var _context= new Online_Food_ApplicationContext())
                {
                    Role role = new Role();
                    role = _context.TblRoles.Where(x => x.IsActive == true && x.RoleId == id).Select(x => new Role
                    {
                        RoleId = x.RoleId,
                        Roles = x.Role,
                        IsActive = x.IsActive
                    }).FirstOrDefault();
                    return role;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> RemoveRoles(int id,Role role)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblRole tbl =await _context.TblRoles.FindAsync(id);
                if(tbl != null)
                {
                    tbl.IsActive = false;
                    tbl.DeletedDate=DateTime.Now;
                    tbl.DeletedBy = role.DeletedBy;
                }
                _context.TblRoles.Update(tbl);
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<bool> UpdateRoles(int id ,Role role)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblRole tbl = await _context.TblRoles.FindAsync(id);
                if (tbl != null)
                {
                    tbl.Role = role.Roles;
                    tbl.UpdatedBy = role.UpdatedBy;
                    role.UpdatedDate = DateTime.Now;
                }
                _context.TblRoles.Update(tbl);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
