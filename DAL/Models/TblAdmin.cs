using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblAdmin
    {
        public TblAdmin()
        {
            TblAdminSessions = new HashSet<TblAdminSession>();
        }

        public int AdminId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; } = null!;
        public string AdminName { get; set; } = null!;
        public byte[]? Image { get; set; }
        public string FullAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? IsActive { get; set; }

        public virtual TblRole Role { get; set; } = null!;
        public virtual ICollection<TblAdminSession> TblAdminSessions { get; set; }
    }
}
