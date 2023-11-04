using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class Admin
    {
        public Admin()
        {
            AdminSessions = new HashSet<AdminSession>();
        }
        public IFormFile imageFile_Admin { get; set; }
        public int AdminId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; } = null!;
        public string AdminName { get; set; } = null!;
        public byte[]? Image { get; set; }
        public string FullAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? IsActive { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<AdminSession> AdminSessions { get; set; }
    }
}
