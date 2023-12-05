using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface CartDAO
    {
        Task<bool> AddtoCart(Cart _cart);
        Task<List<Cart>> GetAllItems(int UserID);
        Task<bool> DeleteItems(int CartID,int UserID);
        Task<bool> CheckIfExist(int FoodID, int UserID);
        Task<bool> AddToExisting(int FoodID, int UserID);
        Task<int> increaseQuantity(int FoodID, int UserID);
        Task<int> decreaseQuantity(int FoodID, int UserID);
        Task<decimal> GetOverallPrice(int UserID);
        Task<int> GetTotalNumberOFItemsInCart(int UserID);
    }
}
