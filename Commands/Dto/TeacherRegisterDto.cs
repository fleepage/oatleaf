using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands.Dto
{
    public class TeacherRegisterDto
    {
        public UserRegisterDto NewUser { get; set; }
        public long UserId { get; set; }
        public long SchoolId { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
    }
}
