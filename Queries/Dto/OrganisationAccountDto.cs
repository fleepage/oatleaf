using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class OrganisationAccountDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public string BlockedMessage { get; set; }
    }
}
