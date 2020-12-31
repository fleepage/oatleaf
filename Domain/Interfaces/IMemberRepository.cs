using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<CreateMemberResponse> Create(Member member);
    }
}
