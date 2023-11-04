using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface RolesDAO
    {
        Task<bool> AddRoles(Role role);
        Task<bool> RemoveRoles(int id,Role role);
        Task<bool> UpdateRoles(int id,Role role);
        Task<List<Role>> GetAllRoles(); 
        Task<Role> GetRoleByID(int id);
    }
}
