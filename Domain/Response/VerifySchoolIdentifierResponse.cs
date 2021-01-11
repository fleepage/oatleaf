using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Response
{
    public class VerifySchoolIdentifierResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool IsExisting { get; set; }
    }
}
