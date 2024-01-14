using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Implementation
{
    public class CartDao:CartDAO
    {
        public async Task<bool> AddtoCart(Cart _cart)
        {
           await using (var _context= new Online_Food_ApplicationContext())
            {
                int CartID = _context.TblCarts.Max(x => (int?)x.CartId) ?? 0;
                TblCart cart = new TblCart();
                cart.CartId = (short)(CartID + 1);
                cart.CartStatus ="Pending";
                cart.Quantity = _cart.Quantity;
                cart.FoodId=_cart.FoodId;
                cart.UserId = _cart.UserId;
                cart.AddedDate = DateTime.Now;
                _context.TblCarts.Add(cart);
                _context.SaveChanges();
            }
                return true;
        }
        public async Task<List<Cart>> GetAllItems(int UserID)
        {
            await using (var _context = new Online_Food_ApplicationContext()) 
            {
                List<Cart> listCart = _context.TblCarts.Where(x => x.UserId == UserID&&x.CartStatus=="Pending").Select(x => new Cart()
                {
                    CartId=x.CartId,
                    CartStatus=x.CartStatus,
                    AddedDate=x.AddedDate,
                    FoodId=x.FoodId,
                    UserId=x.UserId,
                    Quantity = x.Quantity,
                    FoodName=x.Food.FoodName,
                    BannerImage=x.Food.BannerImage,
                    Stock=(int)x.Food.Quantity,
                    TotalFoodPrice=(x.Food.FoodAmount)*(x.Quantity),
                    FoodAmount=x.Food.FoodAmount
                }).ToList();
                return listCart;
            }

        }
        public async Task<bool> DeleteItems(int FoodID,int UserID)
        {
            try
            {
                await using(var _context= new Online_Food_ApplicationContext())
                {
                   TblCart tbl =   _context.TblCarts.Where(x=>x.FoodId==FoodID&&x.UserId==UserID).Select(x=>new TblCart
                   {
                       CartId = x.CartId,
                       CartStatus = x.CartStatus,
                       AddedDate = x.AddedDate,
                       FoodId = x.FoodId,
                       UserId = x.UserId,
                       Quantity = x.Quantity,
                       Food=x.Food
                   }).FirstOrDefault();
                   
                    if (tbl != null)
                    {
                        _context.TblCarts.Remove(tbl);
                        _context.Entry(tbl).State = EntityState.Deleted;
                        _context.SaveChanges();
                        return true;

                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> CheckIfExist(int FoodID,int UserID)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblCart tbl=_context.TblCarts.SingleOrDefault(x => x.FoodId == FoodID && x.UserId == UserID&&x.CartStatus=="Pending");
                if(tbl != null) 
                    return true;
                else
                    return false;
            }
        }
        
        public async Task<bool> AddToExisting(int FoodID,int UserID)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblCart tbl = _context.TblCarts.Where(x => x.FoodId == FoodID && x.UserId == UserID && x.CartStatus == "Pending").Select(x => new TblCart()
                {
                    CartId = x.CartId,
                    CartStatus = x.CartStatus,
                    AddedDate = x.AddedDate,
                    FoodId = x.FoodId,
                    UserId = x.UserId,
                    Quantity = x.Quantity,
                   Food=x.Food
                }).FirstOrDefault();
                if (tbl!= null)
                {
                    if (tbl.Food.Quantity> tbl.Quantity + 1)
                    {
                        tbl.Quantity = tbl.Quantity + 1;
                        _context.TblCarts.Update(tbl);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                    return false;
            }
        }

        public async Task<int> increaseQuantity(int FoodID, int UserID)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblCart tbl = _context.TblCarts.Where(x => x.UserId == UserID && x.FoodId == FoodID && x.CartStatus == "Pending").FirstOrDefault();
                
                if(tbl != null ) 
                {
                   
                        tbl.Quantity = tbl.Quantity + 1;
                        _context.TblCarts.Update(tbl);
                        _context.SaveChanges();
                        return 1;

                }
                else
                {
                    return 0;
                }

            }
        }

        public async Task<int> decreaseQuantity(int FoodID, int UserID)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblCart tbl= _context.TblCarts.Where(x => x.UserId == UserID && x.FoodId == FoodID && x.CartStatus == "Pending").FirstOrDefault();
                if(tbl != null)
                {
                    tbl.Quantity = tbl.Quantity - 1;
                    if (tbl.Quantity <= 0)
                    {
                        return 0;
                    }
                    else
                    {
                        _context.TblCarts.Update(tbl);
                        _context.SaveChanges();
                        return 1;
                    }
                    
                }
                else
                {
                    return 0;
                }
            }
        }

        public async Task<decimal> GetOverallPrice(int UserID)
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                var TotalAmount = _context.TblCarts.Where(x => x.UserId == UserID && x.CartStatus == "Pending").GroupBy(x => x.UserId).Select(g => new
                {
                    UserID = g.Key,//this key is used to get the key used for grouping in group by here it will get the userid
                    TotalAmount = g.Sum(x => x.Food.FoodAmount * x.Quantity)

                }).ToList();
                decimal finalAmount = TotalAmount.Sum(item => item.TotalAmount);
                return finalAmount;
            }
        }
        public async Task<int> GetTotalNumberOFItemsInCart(int UserID)
        {

            await using (var _context = new Online_Food_ApplicationContext())
            {
                int Total = _context.TblCarts.Where(x => x.UserId == UserID && x.CartStatus == "Pending").Count();
                return Total;
            }
        }
    }
}
