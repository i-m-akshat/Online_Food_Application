using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AdminViewModel
    {
        public List<Admin> listAdmin { get; set; }
        public List<OrderGroup> listOrder { get; set; }
        public List<PaymentDetail> paymentDetail { get; set; }
        public List<User> user { get; set; }
        public int count_Orders { get; set; }
        public int count_Payments { get; set; }
        public decimal sum_earnings { get; set; }
        public int count_Users { get; set; }
        public int count_Admins { get; set; }
    }
    public class OrderGroup
    {
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
    public class PaymentGroup
    {
        public decimal Sum_payment { get; set; }
        public int Count { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }  
        public string Date { get; set; }
    }
    public class AdminGroup
    {
        public int Count { get; set; }
        public string Role { get; set; }
    }
    public class UserGroup
    {
        public int Count { get; set; }
        public string MonthName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthYear { get; set; }
    }
}
