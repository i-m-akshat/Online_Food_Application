using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using OnlineFastFoodDelivery;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public async Task<List<OrderGroup>> ReturnOrdersPerMonth()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                List<OrderGroup> listOrder = new List<OrderGroup>();

                listOrder = _context.TblOrders.Where(x => x.OrderStatus!="Cancelled").GroupBy(x => x.ProcessedDate).Select(group => new OrderGroup
                {
                    Count = group.Count(),
                    Date = (DateTime)group.Key
                }).OrderBy(group => group.Date).ToList();
                
                
                return listOrder;
            }
        }
        public async Task<List<PaymentGroup>> ReturnPaymentPerMonth()
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    List<PaymentGroup> listPaymentGroups = new List<PaymentGroup>();
                    listPaymentGroups = _context.TblPaymentDetails.GroupBy(x =>new { ((DateTime)x.PaymentDate).Month,((DateTime)x.PaymentDate).Year}).Select(group => new PaymentGroup
                    {
                       Sum_payment = group.Sum(x=>x.Amount),
                        Year = group.Key.Year,
                        Month = group.Key.Month,
                        Count=group.Count(),
                        MonthName =CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month),
                        Date = (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month)).Substring(0,3) + " " + group.Key.Year,
                    }).OrderBy(group => group.Year).ThenBy(group=>group.Month).ToList();
                    return listPaymentGroups;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        public async Task<List<AdminGroup>> GetAdminCountByRoles()
        {
            using (var _context=new Online_Food_ApplicationContext())
            {
                List<AdminGroup> listAdmins = new List<AdminGroup>();
                listAdmins = _context.TblAdmins.GroupBy(x => x.Role.Role).Select(group => new AdminGroup
                {
                    Count = group.Count(),
                    Role=group.Key
                }).OrderBy(x=>x.Role).ToList();
                return listAdmins;
            }
        }

        public async Task<List<UserGroup>> GetUserByDate()
        {
            using (var _context = new Online_Food_ApplicationContext())
            {
                List<UserGroup> listuser = new List<UserGroup>();
                listuser = _context.TblUsers.GroupBy(x => new { ((DateTime)x.AddedDate).Year, ((DateTime)x.AddedDate).Month}).Select(group => new UserGroup
                {
                    Count = group.Count(),
                    Year=group.Key.Year,
                    Month=group.Key.Month,
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month).Substring(0,3),
                    MonthYear=(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month).Substring(0, 3))+" "+group.Key.Year
                }).OrderBy(x=>x.Year).ThenBy(x=>x.Month).ToList();
                return listuser;
            }
        }

        public async Task<int> getCountOrders()
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                int res = _context.TblOrders.Count(x => x.OrderStatus != "Cancelled");
                return res;
            }
        }

        public async Task<int> getCountPayment()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                int res = _context.TblPaymentDetails.Count(x=>x.PaymentId!=null);
                return res;
            }
        }

        public async Task<Decimal> getSumEarnings()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                decimal res = _context.TblPaymentDetails.Sum(x => x.Amount);
                return res;
            }
        }

        public async Task<int> getCountUsers()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                int res = _context.TblUsers.Count(x => x.UserId != null);
                return res;
            }
        }

        public async Task<int> getCountAdmins()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                int res = _context.TblAdmins.Count(x => x.AdminId != null);
                return res;
            }
        }
    }
}
