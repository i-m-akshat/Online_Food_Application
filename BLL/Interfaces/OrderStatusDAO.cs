using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface OrderStatusDAO
    {
        Task<orderModel> GetAllOrders(int CurrentPage);
        Task<bool> Cancel(int Orderid);
        Task<bool> Waiting(int orderID);
        Task<bool> PickedByCourierPartner(int orderID );
        Task<bool> InTransit(int orderID );
        Task<bool> PickedByDeliveryPerson(int orderID );
        Task<bool> OutForDelivery(int orderID );
        Task<bool> Delivered(int OrderID );
        Task<string> GetEmailbyOrderID(int id);
    }
}
