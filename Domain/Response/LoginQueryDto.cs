using fleepage.oatleaf.com.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Response
{
    public class LoginQueryDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public UserDto UserDto { get; set; }
    }
}
