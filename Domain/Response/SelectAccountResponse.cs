using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Response
{
    public class SelectAccountResponse
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string token { get; set; }
        public ICollection<PermissionAccountDto> Permissions { get; set; }

    }
}
