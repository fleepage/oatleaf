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
    public class CreateTeacherCommand : IRequest<CreateTeacherResponse>
    {
        public TeacherRegisterDto registerDto { get; set; }

        public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, CreateTeacherResponse>
        {
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IGenericRepository<Accounts> accountRepository;
            private readonly ITeacherRepository teacherRepository;
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public CreateTeacherCommandHandler(IUserRepository userRepository, ITeacherRepository teacherRepository, IGenericRepository<Accounts> accountRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateTeacherResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
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
                        var res = await userRepository.Register(usr, request.registerDto.NewUser.Password, request.registerDto.NewUser.PasswordConfirmation, "teacher");
                        if (res.IsSuccess)
                        {
                            userId = res.User.Id;
                        }
                        else
                        {
                            throw new AppException(res.Message);
                        }
                    }


                    var teacher = mapper.Map<Teacher>(request.registerDto);
                    teacher.UserId = userId;
                    var account = await accountRepository.Add(new Accounts { Role = "Teacher", isActive = true, UserId = userId });
                    teacher.AccountsId = account.Id;
                    var result = await teacherRepository.Create(teacher);


                    if (result.IsSuccess)
                    {
                        var permissions = new List<Permissions> {
                    new Permissions{
                    Permission="work",
                    Level="rw",
                    TeachersId=result.Teacher.Id
                    },
                    new Permissions{
                    Permission="student",
                    Level="r",
                    TeachersId=result.Teacher.Id
                    },
                    new Permissions{
                    Permission="assessment",
                    Level="rw",
                    TeachersId=result.Teacher.Id
                    },
                    new Permissions{
                    Permission="media",
                    Level="rw",
                    TeachersId=result.Teacher.Id
                    },
                    new Permissions{
                    Permission="event",
                    Level="r",
                    TeachersId=result.Teacher.Id
                    },

                    };

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
                    return new CreateTeacherResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
