using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Authenticate(AuthenticateDto dto);
        Task<CreateUserResponse> Register(User user, string password, string passwordConfirmation, string role);
        //Task<string> ChangeUsername(long user, string username);
    }
}
