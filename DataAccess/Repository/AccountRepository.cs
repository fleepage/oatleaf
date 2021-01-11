using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.DataAccess.Repository
{
    public class AccountRepository : GenericRepository<Accounts>, IAccountRepository
    {

        private readonly ApplicationDbContext context;
        private readonly AppSettings _appSettings;
        public AccountRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings.Value;

        }



        public async Task<Accounts> ActivateAccount(Accounts accounts)
        {
            var existingAccount = await context.Accounts.FirstOrDefaultAsync(x => x.UserId == accounts.UserId && x.Role == accounts.Role );

            if (existingAccount?.UserId == accounts.UserId)
                return existingAccount;


            await context.AddAsync(accounts);
            await context.SaveChangesAsync();

            return accounts;
        }

        public async Task<ICollection<Accounts>> MyAccounts(long user)
        {
            var myAccounts = await context.Accounts
     .Include(a => a.Students.School)
     .Include(a => a.Parent)
     .Include(a => a.Teachers.School)
     .Include(a => a.Staffs.School)
     .Include(a => a.OrgAdmin.Organisation)
     .Include(a => a.SchoolAdmin.School)
     .Where(x => x.UserId == user).ToListAsync();

            return myAccounts;
        }

        public async Task<Accounts> Select(long account, long user)
        {
            var myAccount = await context.Accounts
                .Include(a => a.Students.Permissions)
                .Include(a => a.Parent.Permissions)
                .Include(a => a.Teachers.Permissions)
                .Include(a => a.Staffs.Permissions)
                .Include(a => a.OrgAdmin.Permissions)
                .Include(a => a.SchoolAdmin.Permissions)
                 .SingleOrDefaultAsync(x => x.Id == account && x.UserId == user);

            return myAccount;
        }
    }
}
