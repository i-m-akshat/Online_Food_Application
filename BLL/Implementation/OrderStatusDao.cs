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
    public class OrderStatusDao : OrderStatusDAO
    {
        public async Task<bool> Cancel(int Orderid)
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == Orderid).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "Cancelled";
                    _context.TblOrders.Update(tbl);
                    TblPaymentDetail tblPay=_context.TblPaymentDetails.Where(x=>x.PaymentId==tbl.PaymentId).FirstOrDefault();
                    if (tblPay != null)
                    {
                        _context.TblPaymentDetails.Remove(tblPay);
                    }
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;   
                }
            }
        }


        public async Task<bool> Delivered(int OrderID)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == OrderID).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "Delivered";
                    _context.TblOrders.Update(tbl);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<orderModel> GetAllOrders(int currentPage)
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                int maxRows = 10;
                orderModel _model = new orderModel();
                _model.listOrder= _context.TblOrders.Where(x => x.OrderStatus != "Cancelled"&&x.OrderStatus!="Delivered").Select(x => new Order
                {
                    OrderId = x.OrderId,
                    OrderStatus = x.OrderStatus,
                    OrderDate = x.OrderDate,
                    UserId = x.UserId,
                    TotalAmount=x.TotalAmount,
                    ProcessedBy = x.ProcessedBy,
                    ProcessedDate = x.ProcessedDate,
                    ProcessedBy_Name=x.ProcessedByNavigation.FullName
                   
                }).OrderBy(x=>x.OrderId).Skip((currentPage-1)*maxRows).Take(maxRows).ToList();
                double pageCount = (double)((decimal)_context.TblOrders.Count()/Convert.ToDecimal(maxRows));
                _model.PageCount=(int)Math.Ceiling(pageCount);
                _model.CurrentPageIndex = currentPage;
                return _model;
            }
        }

       

        public async Task<bool> InTransit(int orderID)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == orderID).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "InTransit";
                    _context.TblOrders.Update(tbl);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

      

        public async Task<bool> OutForDelivery(int orderID)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == orderID).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "Out For Delivery";
                    _context.TblOrders.Update(tbl);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

      
        public async Task<bool> PickedByCourierPartner(int orderID)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == orderID).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "Picked By Courier Partner";
                    _context.TblOrders.Update(tbl);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

      

        public async Task<bool> PickedByDeliveryPerson(int orderID)
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == orderID).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "Picked By Delivery Person";
                    _context.TblOrders.Update(tbl);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> Waiting(int orderID)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblOrder tbl = _context.TblOrders.Where(x => x.OrderId == orderID).FirstOrDefault();
                if (tbl != null)
                {
                    tbl.OrderStatus = "Waiting to get picked up by delivery partner";
                    _context.TblOrders.Update(tbl);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<string> GetEmailbyOrderID(int id)
        {
            using (var _context= new Online_Food_ApplicationContext())
            {
                string Email = _context.TblOrders.Where(x => x.OrderId == id).Select(x => x.User.Email).FirstOrDefault();
                return Email;
            }
        }
    }
}
