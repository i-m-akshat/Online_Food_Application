using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.Interfaces
{
    public interface AddAdminDAO
    {
        Task<bool> AddAdmin(Admin admin);
        Task<bool> DeletedAdmin(int id);
        Task<bool> UpdateAdmin(int id, Admin admin);
        Task<List<Admin>> GetAllAdmins();
        Task<Admin> GetAdmin(int id);
        Task<List<Role>> GetAllRoles(); 
    }
}
