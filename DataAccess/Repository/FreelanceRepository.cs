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
    public class FreelanceRepository : GenericRepository<Freelance>, IFreelanceRepository
    {

        private readonly ApplicationDbContext context;

        public FreelanceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<EnableFreelanceResponse> Create(Freelance freelance)
        {
            var existingFreelance = await context.Freelance.FirstOrDefaultAsync(x => x.UserId == freelance.UserId);

            if (existingFreelance?.UserId == freelance.UserId)
                return new EnableFreelanceResponse { Message = "Freelance Account already activated.", IsSuccess = false, Status = "", Freelance = existingFreelance };


            await context.AddAsync(freelance);
            await context.SaveChangesAsync();

            return new EnableFreelanceResponse { Message = "Freelance Account Activated.", IsSuccess = true, Freelance = freelance, Status = "200" };
        }
    }
}
