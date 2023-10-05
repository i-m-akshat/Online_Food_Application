using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            OrderProcessedByNavigations = new HashSet<Order>();
            OrderUsers = new HashSet<Order>();
            PaymentDetails = new HashSet<PaymentDetail>();
            Ratings = new HashSet<Rating>();
        }
        public IFormFile imageFile { get; set; }
        public long UserId { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public byte[]? Image { get; set; }
        public string? FullAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? AccountStatus { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> OrderProcessedByNavigations { get; set; }
        public virtual ICollection<Order> OrderUsers { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }

}
