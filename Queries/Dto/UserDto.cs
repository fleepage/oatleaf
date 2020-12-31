using fleepage.oatleaf.com.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string TempPassword { get; set; }
        public string OtherNames { get; set; }
        //public DateTime? LastLoginDate { get; set; }
        public ICollection<AccountDto> Accounts { get; set; }
        public string Token { get; set; }
    }
}
