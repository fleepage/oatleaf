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
    public class OrganisationRepository : GenericRepository<Organisation>, IOrganisationRepository
    {

        private readonly ApplicationDbContext context;

        public OrganisationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<CreateOrganisationResponse> Create(Organisation orgainsation)
        {
            var existingOrganisation = await context.Organisation.FirstOrDefaultAsync(x => x.Identifier == orgainsation.Identifier);

            if (existingOrganisation?.Identifier == orgainsation.Identifier)
                return new CreateOrganisationResponse { IsSuccess = false, Message = string.Format("'{0}' is already existing.", orgainsation.Identifier), Identifier = existingOrganisation.Identifier };

            await context.AddAsync(orgainsation);
            await context.SaveChangesAsync();

            var freeSub = await context.Subscription.FirstOrDefaultAsync(x => x.Code == "TRIAL");

            if (freeSub.IsAvailable)
            {
                var sub = new Subscriptions
                {
                    SubscriberId = orgainsation.Id,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(freeSub.Duration),
                    IsActive = true,
                    SubscriptionID = freeSub.Id,
                    Count = 0,
                    Amount = (0 * freeSub.ActivePrice),
                };

                await context.Subscriptions.AddAsync(sub);
                await context.SaveChangesAsync();

            }

            return new CreateOrganisationResponse { IsSuccess = true, Message = "Orgainisation has been registered successfully", Identifier = orgainsation.Identifier, OrganisationId = orgainsation.Id };
        }
    }
}
