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
    public class CreateStaffCommand : IRequest<CreateStaffResponse>
    {
        public StaffRegisterDto registerDto { get; set; }

        public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, CreateStaffResponse>
        {
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IGenericRepository<Accounts> accountRepository;
            private readonly IStaffRepository staffRepository;
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public CreateStaffCommandHandler(IUserRepository userRepository, IStaffRepository staffRepository, IGenericRepository<Accounts> accountRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateStaffResponse> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
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
                        var res = await userRepository.Register(usr, request.registerDto.NewUser.Password, request.registerDto.NewUser.PasswordConfirmation, "staff");
                        if (res.IsSuccess)
                        {
                            userId = res.User.Id;
                        }
                        else
                        {
                            throw new AppException(res.Message);
                        }
                    }


                    var staff = mapper.Map<Staffs>(request.registerDto);
                    staff.UserId = userId;
                    var account = await accountRepository.Add(new Accounts { Role = "Staff", isActive = true, UserId = userId });
                    staff.AccountsId = account.Id;
                    var result = await staffRepository.Create(staff);


                    if (result.IsSuccess)
                    {
                        var permissions = new List<Permissions> {};

                        foreach (PermissionAccountDto permit in request.registerDto.Permissions) {
                            permissions.Add(
                                new Permissions
                            {
                                Permission = permit.Permission,
                                Level = permit.Level,
                                StaffsId = result.Staff.Id
                            } );
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
                    return new CreateStaffResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
