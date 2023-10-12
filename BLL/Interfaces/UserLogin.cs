using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface UserLogin
    {
        public Task<User> GetUserDetails(string UserID, string Password);
        public Task<bool> SignUp(User user);
        Task<User> Login(string Username, string Password);
    }
}
