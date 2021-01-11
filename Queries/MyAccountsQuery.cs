using AutoMapper;
using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Helper;
using fleepage.oatleaf.com.Helper.Exceptions;
using fleepage.oatleaf.com.Queries.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries
{
    public class MyAccountsQuery : IRequest<MyAccountsResponse>
    {
        public long user { get; set; }

        public class MyAccountsQueryHandler : IRequestHandler<MyAccountsQuery, MyAccountsResponse>
        {
            private readonly IAccountRepository accountRepository;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public MyAccountsQueryHandler(IAccountRepository accountRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<MyAccountsResponse> Handle(MyAccountsQuery query, CancellationToken cancellationToken)
            {


                try
                {
                    var accounts = await accountRepository.MyAccounts(query.user);
                    return new MyAccountsResponse
                    {
                        IsSuccess =true,
                        Message = "my accounts",
                        MyAccounts = mapper.Map<ICollection<MyAccountsDto>>(accounts),
                    };
                }
                catch (EntityNotFoundException ex)
                {

                    return new MyAccountsResponse
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                }
                catch (AppException ex)
                {

                    return new MyAccountsResponse
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };

                }
                catch (Exception e)
                {
                    return new MyAccountsResponse
                    {
                        IsSuccess = false,
                        Message = e.Message,
                    };
                }

            }

        }
    }
}
