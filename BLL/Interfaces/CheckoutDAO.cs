using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface CheckoutDAO
    {
        Task<int> Checkout_Order(Order order);
        Task<int> Checkout_OrderDetails(OrderDetail orderDetails);
        Task<int> CheckOut_PaymentDetails(PaymentDetail payDetails);
        void ChangeCartStatus(int Userid,int Cartid);
        void changeFoodQuantity(int Foodid,int Quantity);
        Task<string> GetEmailbyUserID(int Userid);
    }
}
