using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    public partial class Role
    {
        public Role()
        {
            Admins = new HashSet<Admin>();
        }

        public int RoleId { get; set; }
        public string? Roles { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual AdminSession? CreatedByNavigation { get; set; }
        public virtual AdminSession? DeletedByNavigation { get; set; }
        public virtual AdminSession? UpdatedByNavigation { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}
