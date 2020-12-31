using AutoMapper;
using fleepage.oatleaf.com.Commands.Dto;
using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Helper.Exceptions;
using fleepage.oatleaf.com.Queries.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands
{
    public class AddMemberCommand : IRequest<CreateMemberResponse>
    {
        public MemberRegisterDto registerDto { get; set; }

        public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, CreateMemberResponse>
        {
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IGenericRepository<Accounts> accountRepository;
            private readonly IMemberRepository memberRepository;
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public AddMemberCommandHandler(IUserRepository userRepository, IMemberRepository memberRepository, IGenericRepository<Accounts> accountRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateMemberResponse> Handle(AddMemberCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    long userId = 0;


                    if (request.registerDto.UserId > 0)
                    {
                        userId = request.registerDto.UserId;
                    }
                    else
                    {
                        var password = fleepage.oatleaf.com.Helper.RandomGenerator.GenerateEmailCode(8);
                        var usr = mapper.Map<User>(request.registerDto.NewUser);
                        request.registerDto.NewUser.Password = password;
                        request.registerDto.NewUser.PasswordConfirmation = password;
                        usr.TempPassword = password;
                        var res = await userRepository.Register(usr, request.registerDto.NewUser.Password, request.registerDto.NewUser.PasswordConfirmation, "member");
                        if (res.IsSuccess)
                        {
                            userId = res.User.Id;
                        }
                        else
                        {
                            throw new AppException(res.Message);
                        }
                    }


                    var member = mapper.Map<Member>(request.registerDto);
                    member.UserId = userId;
                    var account = await accountRepository.Add(new Accounts { Role = "Member", isActive = true, UserId = userId });
                    member.AccountsId = account.Id;
                    var result = await memberRepository.Create(member);


                    if (result.IsSuccess)
                    {
                        var permissions = new List<Permissions> { };

                        foreach (PermissionAccountDto permit in request.registerDto.Permissions)
                        {
                            permissions.Add(
                                new Permissions
                                {
                                    Permission = permit.Permission,
                                    Level = permit.Level,
                                    MemberId = result.Member.Id
                                });
                        }

                        await permissionRepository.Add(permissions);
                        await permissionRepository.CommitAsync();
                    }

                    else
                    {
                        accountRepository.Delete(account);
                        await accountRepository.CommitAsync();
                    }

                    return result;
                }
                catch (Exception e)
                {
                    return new CreateMemberResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
