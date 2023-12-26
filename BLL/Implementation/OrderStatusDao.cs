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

        public async Task<List<Order>> GetAllOrders()
        {
            await using (var _context=new Online_Food_ApplicationContext())
            {
                List<Order> listOrder = _context.TblOrders.Where(x => x.OrderStatus != "Cancelled").Select(x => new Order
                {
                    OrderId = x.OrderId,
                    OrderStatus = x.OrderStatus,
                    OrderDate = x.OrderDate,
                    UserId = x.UserId,
                    TotalAmount=x.TotalAmount,
                    ProcessedBy = x.ProcessedBy,
                    ProcessedDate = x.ProcessedDate,
                    ProcessedBy_Name=x.ProcessedByNavigation.FullName
                   
                }).ToList();
                return listOrder;
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
    }
}
