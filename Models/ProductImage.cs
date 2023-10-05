using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductImage
    {
       
            public long ProductImgId { get; set; }
            public byte[] ProductImg { get; set; } = null!;
            public long FoodId { get; set; }
            public bool IsActive { get; set; }
            public long? CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public long? UpdatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public long? DeletedBy { get; set; }
            public DateTime? DeletedDate { get; set; }

            public virtual AdminSession? CreatedByNavigation { get; set; }
            public virtual AdminSession? DeletedByNavigation { get; set; }
            public virtual Food Food { get; set; } = null!;
            public virtual AdminSession? UpdatedByNavigation { get; set; }
       
    }
}
