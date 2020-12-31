using AutoMapper;
using fleepage.oatleaf.com.Commands.Dto;
using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Helper.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands
{
    public class CreateParentCommand : IRequest<CreateParentResponse>
    {
        public ParentRegisterDto registerDto { get; set; }

        public class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, CreateParentResponse>
        {
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IAccountRepository accountRepository;
            private readonly IParentRepository parentRepository;
            private readonly IStudentRepository studentRepository;
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public CreateParentCommandHandler(IUserRepository userRepository, IParentRepository parentRepository, IAccountRepository accountRepository, IStudentRepository studentRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.parentRepository = parentRepository ?? throw new ArgumentNullException(nameof(parentRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateParentResponse> Handle(CreateParentCommand request, CancellationToken cancellationToken)
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
                        var res = await userRepository.Register(usr, request.registerDto.NewUser.Password, request.registerDto.NewUser.PasswordConfirmation, "Parent");
                        if (res.IsSuccess)
                        {
                            userId = res.User.Id;
                        }
                        else
                        {
                            throw new AppException(res.Message);
                        }
                    }


                    var parent = mapper.Map<Parent>(request.registerDto);
                    parent.UserId = userId;
                    var account = await accountRepository.ActivateAccount(new Accounts { Role = "Parent", isActive = true, UserId = userId });
                    parent.AccountsId = account.Id;
                    var result = await parentRepository.Create(parent);



                    if (result.IsSuccess)
                    {
                        var permissions = new List<Permissions> {
                    new Permissions{
                    Permission="work",
                    Level="rw",
                    ParentId=result.Parent.Id
                    },
                    new Permissions{
                    Permission="children",
                    Level="r",
                    ParentId=result.Parent.Id
                    },
                    new Permissions{
                    Permission="financials",
                    Level="rw",
                    ParentId=result.Parent.Id
                    },
                    };

                        await permissionRepository.Add(permissions);
                        await permissionRepository.CommitAsync();
                    }

                    await studentRepository.AssignParent(request.registerDto.StudentId,result.Parent.Id);

                    return result;
                }
                catch (Exception e)
                {
                    return new CreateParentResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
