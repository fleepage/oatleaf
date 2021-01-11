using fleepage.oatleaf.com.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Accounts>
    {
        Task<ICollection<Accounts>> MyAccounts(long user);
        Task<Accounts> Select(long account,long user);
        Task<Accounts> ActivateAccount(Accounts accounts);

    }
}

