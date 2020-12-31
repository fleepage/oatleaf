using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class OrgAdminDto
    {
        public long UserId { get; set; }
        public long OrganisationId { get; set; }
        public long? AccountsId { get; set; }
    }
}
