using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface AdminLogin
    {
        public Task<Admin> Login(string AdminName, string Password);
        //public Task<Admin> Logout();
        Admin getImage(int AdminID);
    }
}
