using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.DataAccess.Repository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {

        private readonly ApplicationDbContext context;

        public MemberRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<CreateMemberResponse> Create(Member member)
        {
            var existingMember = await context.Member.FirstOrDefaultAsync(x => x.OrganisationId == member.OrganisationId && x.UserId == member.UserId);

            if (existingMember?.UserId == member.UserId)
                return new CreateMemberResponse { Message = "Already a Member of your organisation.", IsSuccess = false, Status = "" };


            await context.AddAsync(member);
            await context.SaveChangesAsync();

            return new CreateMemberResponse { Message = "New Member Added.", IsSuccess = true, Member = member, Status = "200" };
        }
    }
}
