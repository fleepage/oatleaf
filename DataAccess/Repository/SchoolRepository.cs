using fleepage.oatleaf.com.Commands.Dto;
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
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {

        private readonly ApplicationDbContext context;
        
        public SchoolRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            


        }

        public async Task<CreateSchoolResponse> Create(School schoolDto)
        {
            var existingSchool = await context.Schools.FirstOrDefaultAsync(x => x.Identifier == schoolDto.Identifier);

            if (existingSchool?.Identifier == schoolDto.Identifier)
                return new CreateSchoolResponse { IsSuccess = false, Message = string.Format("'{0}' is already existing.", schoolDto.Identifier), Identifier = existingSchool.Identifier };

            await context.AddAsync(schoolDto);
            await context.SaveChangesAsync();

            var freeSub = await context.Subscription.FirstOrDefaultAsync(x => x.Code == "TRIAL");

            if (freeSub.IsAvailable) {
                var sub = new Subscriptions
                {
                    SubscriberId = schoolDto.Id,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(freeSub.Duration),
                    IsActive = true,
                    SubscriptionID = freeSub.Id,
                    Count=0,
                    Amount = (0 *freeSub.ActivePrice),
                };

                await context.Subscriptions.AddAsync(sub);
                await context.SaveChangesAsync();

            }

            return new CreateSchoolResponse { IsSuccess = true, Message = "School has been registered successfully", Identifier = schoolDto.Identifier, SchoolId = schoolDto.Id };
        }
    }
}
