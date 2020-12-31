using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class SchoolAdminPermissionDto
    {
        public string Permission { get; set; }
        public string Level { get; set; }
        public long? SchoolAdminId { get; set; }
    }
}
