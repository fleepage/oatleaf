using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.BaseEntities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }





    }
}
