using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Response
{
    public class CreateSchoolResponse
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Identifier { get; set; }
        public long SchoolId { get; set; }
    }
}
