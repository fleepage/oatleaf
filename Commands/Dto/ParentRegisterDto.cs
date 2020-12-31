using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands.Dto
{
    public class ParentRegisterDto
    {
        public UserRegisterDto NewUser { get; set; }
        public long UserId { get; set; }
        public long StudentId { get; set; }
        public long SchoolId { get; set; }
    }
}
