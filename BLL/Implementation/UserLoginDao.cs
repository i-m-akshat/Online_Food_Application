using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace BLL.Implementation
{
    public class UserLoginDao : UserLogin
    {
        public async Task<User> GetUserDetails(string UserID, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignUp(User user)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    
                    int UserID = _context.TblUsers.Max(x => (int?)x.UserId) ?? 0;
                    TblUser tbl = new TblUser();
                    tbl.UserId = UserID + 1;
                    tbl.UserName = user.UserName;
                    tbl.Password = user.Password;
                    tbl.Salt = user.Salt;
                    tbl.AccountStatus = "Pending";
                    tbl.IsActive = true;
                    tbl.FullAddress = user.FullAddress;
                    tbl.FullName = user.FullName;
                    tbl.Image = user.Image;
                    tbl.PhoneNumber = user.PhoneNumber;
                    _context.TblUsers.Add(tbl);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<User> Login(string Username, string Password)
        {
            try
            {
                await using ( var _context=new Online_Food_ApplicationContext())
                {
                    var UserDetails =  _context.TblUsers.Where(x => x.UserName == Username && x.Password == Password).Select(x => new User()
                    {
                        FullName = x.FullName,
                        Password = x.Password,
                        UserId = x.UserId,
                        UserName = x.UserName,
                        Image = x.Image,
                        PhoneNumber = x.PhoneNumber,
                        IsActive = x.IsActive
                    }).FirstOrDefault();
                    return UserDetails;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<bool> checkUsername(string Username)
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    var details = _context.TblUsers.Where(x => x.UserName == Username).Select(x => new User()
                    {
                        UserId = x.UserId,
                        UserName = x.UserName,
                        Password = x.Password
                    }).FirstOrDefault();
                    if (details != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> GetHashString(string Username)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                string HashPassword = _context.TblUsers.Where(x => x.UserName == Username).Select(x => x.Password).FirstOrDefault();
                return HashPassword;
            }
        }

        public async Task<List<Order>> GetAllOrders(int UserID)
        {
            try
            {
                await using (var _context= new Online_Food_ApplicationContext())
                {
                    List<Order> listorder = _context.TblOrders.Where(x => x.UserId == UserID).Select(x => new Order
                    {
                        OrderId=x.OrderId,
                        OrderDate=x.OrderDate,
                        OrderStatus=x.OrderStatus,
                        UserId=x.UserId
                    }).ToList();
                        return listorder;
                   
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<OrderDetail>> GetAllOrderDetails(int UserID)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    List<OrderDetail> listorderDetails = _context.TblOrderDetails.Where(x => x.Order.UserId==UserID).Select(x => new OrderDetail
                    {
                        OrderId = x.OrderId,
                        OrderDetailsId = x.OrderDetailsId,
                        FoodId=x.FoodId,
                        FoodName=x.Food.FoodName,
                        OrderStatus=x.Order.OrderStatus,
                        OrderDate=x.Order.OrderDate,
                        Amount=x.Amount,
                        NoOfServings=x.NoOfServings,
                        TotalAmount=x.TotalAmount
                    }).ToList();
                    return listorderDetails;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
