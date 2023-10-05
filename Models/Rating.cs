using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class Rating
    {
        public long RatingId { get; set; }
        public short Ratings { get; set; }
        public string Remarks { get; set; } = null!;
        public long UserId { get; set; }
        public long FoodId { get; set; }
        public long? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedBy { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }
        public virtual AdminSession? DeletedByNavigation { get; set; }
        public virtual Food Food { get; set; } = null!;
        public virtual AdminSession? UpdatedByNavigation { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
