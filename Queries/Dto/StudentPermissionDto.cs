using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class StudentPermissionDto
    {
        public string Permission { get; set; }
        public string Level { get; set; }
        public long? StudentsId { get; set; }
    }
}
