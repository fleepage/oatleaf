using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Beneficiary:BaseEntity
    {
        public long Organisation { get; set; }
        public long student { get; set; }
    }
}
