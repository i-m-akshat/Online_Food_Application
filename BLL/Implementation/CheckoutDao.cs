using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class CheckoutDao : CheckoutDAO
    {
        public async void ChangeCartStatus(int Userid,int Cartid)
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                TblCart tbl=_context.TblCarts.Where(x=>x.UserId==Userid&&x.CartId==Cartid&&x.CartStatus=="Pending").FirstOrDefault();
                if (tbl != null)
                {
                    tbl.CartStatus = "In Process";
                }
                _context.TblCarts.Update(tbl);
                _context.SaveChanges();
            }
        }

        public async void changeFoodQuantity(int Foodid,int Quantity)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                TblFood tbl = _context.TblFoods.Where(x => x.FoodId == Foodid ).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.Quantity = tbl.Quantity - Quantity;
                }
                _context.TblFoods.Update(tbl);
                _context.SaveChanges();
            }
        }

        public async Task<int> Checkout_Order(Order order)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                int order_id = _context.TblOrders.Max(x => (int?)x.OrderId) ?? 0;
                TblOrder tbl = new TblOrder
                {

                    OrderId = order_id + 1,
                    UserId = order.UserId,
                    OrderDate = Convert.ToDateTime(DateTime.Today),
                    TotalAmount = order.TotalAmount,
                    ProcessedBy = order.ProcessedBy,
                    ProcessedDate = Convert.ToDateTime(DateTime.Today),
                    OrderStatus = order.OrderStatus
                };
                _context.TblOrders.Add(tbl);
                _context.SaveChanges();
                return (int)tbl.OrderId;
            }
        }

        public async Task<bool> Checkout_OrderDetails(OrderDetail orderDetails)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                int orderDetails_id = _context.TblOrderDetails.Max(x => (int?)x.OrderDetailsId) ?? 0;
                TblOrderDetail tbl = new TblOrderDetail
                {

                    OrderDetailsId = orderDetails_id + 1,
                    OrderId = orderDetails.OrderId,
                    FoodId = orderDetails.FoodId,
                    Amount = orderDetails.Amount,
                    NoOfServings = orderDetails.NoOfServings,
                    TotalAmount = orderDetails.TotalAmount
                };
                _context.TblOrderDetails.Add(tbl);
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<bool> CheckOut_PaymentDetails(PaymentDetail payDetails)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                int payment_id = _context.TblPaymentDetails.Max(x => (int?)x.PaymentId) ?? 0;
                TblPaymentDetail tbl = new TblPaymentDetail
                {
                    PaymentId = payment_id + 1,
                    OrderId=payDetails.OrderId,
                    Amount=payDetails.Amount,
                    PaidBy=payDetails.PaidBy,
                    PaymentDate= payDetails.PaymentDate,
                    ProcessedBy=payDetails.ProcessedBy,
                    TransactionId=payDetails.TransactionID
                };
                _context.TblPaymentDetails.Add(tbl);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
