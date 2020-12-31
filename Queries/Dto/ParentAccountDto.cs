using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class ParentAccountDto
    {
        public long UserId { get; set; }
        public int Rate { get; set; }
        public long? AccountsId { get; set; }
    }
}
