using Models;
using Models.ViewModel;
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
        Task<List<OrderGroup>> ReturnOrdersPerMonth();
        Task<List<PaymentGroup>> ReturnPaymentPerMonth();
        Task<List<AdminGroup>> GetAdminCountByRoles();
        Task<List<UserGroup>> GetUserByDate();
        Task<int> getCountOrders();
        Task<int> getCountPayment();
        Task<decimal> getSumEarnings();
        Task<int> getCountUsers();
        Task<int> getCountAdmins();

    }
}
