using System;
using System.Collections.Generic;

namespace OnlineFastFoodDelivery
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblAdmins = new HashSet<TblAdmin>();
        }

        public int RoleId { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TblAdminSession? CreatedByNavigation { get; set; }
        public virtual TblAdminSession? DeletedByNavigation { get; set; }
        public virtual TblAdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<TblAdmin> TblAdmins { get; set; }
    }
}
