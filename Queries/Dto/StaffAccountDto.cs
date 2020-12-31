using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class StaffAccountDto
    {
        public long UserId { get; set; }
        public long SchoolId { get; set; }
        public int Rate { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public long? AccountsId { get; set; }
    }
}
