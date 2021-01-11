using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class MemberAccountDto
    {
        public long? UserId { get; set; }
        public long? OrganisationId { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public int Rate { get; set; }
        public long? AccountsId { get; set; }
        public OrganisationAccountDto Organisation { get; set; }
    }
}
