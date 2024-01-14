using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCarts = new HashSet<TblCart>();
            TblOrderProcessedByNavigations = new HashSet<TblOrder>();
            TblOrderUsers = new HashSet<TblOrder>();
            TblPaymentDetails = new HashSet<TblPaymentDetail>();
            TblRatings = new HashSet<TblRating>();
        }

        public long UserId { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public byte[]? Image { get; set; }
        public string? FullAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? AccountStatus { get; set; }
        public bool? IsActive { get; set; }
        public byte[]? Salt { get; set; }
        public string Email { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrderProcessedByNavigations { get; set; }
        public virtual ICollection<TblOrder> TblOrderUsers { get; set; }
        public virtual ICollection<TblPaymentDetail> TblPaymentDetails { get; set; }
        public virtual ICollection<TblRating> TblRatings { get; set; }
    }
}
