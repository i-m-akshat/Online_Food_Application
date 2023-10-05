
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public short CartId { get; set; }
        public long FoodId { get; set; }
        public int Quantity { get; set; }
        public long UserId { get; set; }
        public string CartStatus { get; set; } = null!;
        public DateTime? AddedDate { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
