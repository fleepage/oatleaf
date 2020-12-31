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
    public class ParentRepository : GenericRepository<Parent>, IParentRepository
    {

        private readonly ApplicationDbContext context;

        public ParentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<CreateParentResponse> Create(Parent parent)
        {
            var existingParent = await context.Parents.FirstOrDefaultAsync(x =>  x.UserId == parent.UserId);

            if (existingParent?.UserId == parent.UserId)
                return new CreateParentResponse { Message = "Parent Account already activated.", IsSuccess = false, Status = "", Parent= existingParent };


            await context.AddAsync(parent);
            await context.SaveChangesAsync();

            return new CreateParentResponse { Message = "Parent Account Activated.", IsSuccess = true, Parent = parent, Status = "200" };
        }
    }
}
