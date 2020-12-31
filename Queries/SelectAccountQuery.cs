using AutoMapper;
using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Helper;
using fleepage.oatleaf.com.Queries.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries
{
    public class SelectAccountQuery : IRequest<SelectAccountResponse>
    {
        public SelectAccountDto selectAccountDto { get; set; }

        public class SelectAccountQueryHandler : IRequestHandler<SelectAccountQuery, SelectAccountResponse>
        {
            private readonly IAccountRepository accountRepository;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public SelectAccountQueryHandler(IAccountRepository accountRepository,IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<SelectAccountResponse> Handle(SelectAccountQuery query, CancellationToken cancellationToken)
            {


                try
                {
                    var account = await accountRepository.Select(query.selectAccountDto.Account,query.selectAccountDto.UserId);

                    if (account?.Id == query.selectAccountDto.Account)
                    {
                        string role = "";
                        List<Claim> claims = new List<Claim>();
                        ICollection<PermissionAccountDto> permission = new List<PermissionAccountDto> { };

                        claims.Add(new Claim(ClaimTypes.Name, query.selectAccountDto.UserId + ""));

                        if (account?.Role == "Student")
                        {
                            role = "Student";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.Students?.Permissions);
                            claims.Add(new Claim("Tenant", account.Students.SchoolId + ""));
                            

                            foreach (var permissions in account.Students.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "Admin")
                        {
                            role = "Admin";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.SchoolAdmin?.Permissions);
                            claims.Add(new Claim("Tenant", account.SchoolAdmin.SchoolId + ""));

                            foreach (var permissions in account.SchoolAdmin.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "Freelance")
                        {
                            role = "Freelance";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.Freelance?.Permissions);
                            claims.Add(new Claim("Tenant", account.Freelance.SchoolId + ""));

                            foreach (var permissions in account.Freelance.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "Teacher")
                        {
                            role = "Teacher";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.Teachers?.Permissions);
                            claims.Add(new Claim("Tenant", account.Teachers.SchoolId + ""));

                            foreach (var permissions in account.Teachers.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "Staff")
                        {
                            role = "Staff";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.Staffs?.Permissions);
                            claims.Add(new Claim("Tenant", account.Staffs.SchoolId + ""));

                            foreach (var permissions in account.Staffs.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "Parent")
                        {
                            role = "Parent";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.Parent?.Permissions);
                            foreach (var permissions in account.Parent.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "OrgAdmin")
                        {
                            role = "OrgAdmin";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.OrgAdmin?.Permissions);
                            claims.Add(new Claim("Tenant", account.OrgAdmin.OrganisationId + ""));
                            foreach (var permissions in account.OrgAdmin.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }
                        else if (account?.Role == "Member")
                        {
                            role = "Member";
                            permission = mapper.Map<ICollection<PermissionAccountDto>>(account?.Member?.Permissions);
                            claims.Add(new Claim("Tenant", account.Member.OrganisationId + ""));
                            foreach (var permissions in account.Member.Permissions)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, permissions.Permission + permissions.Level.ToUpper()));
                            }
                        }


                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var tokenString = tokenHandler.WriteToken(token);

                        return new SelectAccountResponse { IsSuccess = true, Message = role + " Account selected. Use the token to access account features", token = tokenString, Permissions = permission, };
                    }
                    else {
                        return new SelectAccountResponse { IsSuccess=false, Message="The current user does not have such account"};
                    }

                    
                }
                catch (Exception e)
                {
                    return new SelectAccountResponse { IsSuccess = false, Message = e.Message };
                }

            }

        }
    }
}
