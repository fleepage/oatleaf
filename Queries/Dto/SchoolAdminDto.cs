using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class SchoolAdminDto
    {
        public long UserId { get; set; }
        public long SchoolId { get; set; }
        public long? AccountsId { get; set; }
        //public ICollection<SchoolAdminPermissionDto> Permissions { get; set; }
    }
}
