using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
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
        [Required(ErrorMessage = "This field is required")]
        public long UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public byte[]? Image { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string? FullAddress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Description = "Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please Enter the Valid Phone Number")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage ="Passowrd atleast contain 8 char consist of atleast 2 letters, 2 digits or symbols")]
        public string? Password { get; set; }
        public byte[]? Salt { get; set; }
        public string? AccountStatus { get; set; }
        public bool? IsActive { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> OrderProcessedByNavigations { get; set; }
        public virtual ICollection<Order> OrderUsers { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }

}
