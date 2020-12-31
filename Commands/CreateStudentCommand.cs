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
    public class CreateStudentCommand : IRequest<StudentRegisterRsponse>
    {
        public StudentRegisterDto registerDto { get; set; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentRegisterRsponse>
        {
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IGenericRepository<Accounts> accountRepository;
            private readonly IStudentRepository studentRepository;
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public CreateStudentCommandHandler(IUserRepository userRepository,IStudentRepository studentRepository, IGenericRepository<Accounts> accountRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<StudentRegisterRsponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {

                try
                {
                        long userId = 0; 


                        if (request.registerDto.UserId > 0) {
                        userId = request.registerDto.UserId;
                    }
                    else {
                        var password = fleepage.oatleaf.com.Helper.RandomGenerator.GenerateEmailCode(8);
                        var usr = mapper.Map<User>(request.registerDto.NewUser);
                        request.registerDto.NewUser.Password = password;
                        request.registerDto.NewUser.PasswordConfirmation = password;
                        usr.TempPassword = password;
                        var res = await userRepository.Register(usr, request.registerDto.NewUser.Password, request.registerDto.NewUser.PasswordConfirmation,"student");
                        if (res.IsSuccess) {
                            userId = res.User.Id;
                        }
                        else {
                            throw new AppException(res.Message);
                        }
                    }


                    var student = mapper.Map<Student>(request.registerDto);
                    student.UserId = userId;
                    var account = await accountRepository.Add(new Accounts { Role = "Student", isActive = true, UserId = userId });
                    student.AccountsId = account.Id;
                    var result = await studentRepository.Register(student);

                    if (result.IsSuccess)
                    {
                        var permissions = new List<Permissions> {
                    new Permissions{
                    Permission="work",
                    Level="rw",
                    StudentsId=result.Student.Id
                    },
                    new Permissions{
                    Permission="assessment",
                    Level="rw",
                    StudentsId=result.Student.Id
                    },
                    new Permissions{
                    Permission="media",
                    Level="rw",
                    StudentsId=result.Student.Id
                    },
                    new Permissions{
                    Permission="event",
                    Level="rw",
                    StudentsId=result.Student.Id
                    },
                    new Permissions{
                    Permission="financials",
                    Level="rw",
                    StudentsId=result.Student.Id
                    },
                    };

                        await permissionRepository.Add(permissions);
                        await permissionRepository.CommitAsync();
                    }

                    else {
                        accountRepository.Delete(account);
                        await accountRepository.CommitAsync();
                    }

                    return result;
                }
                catch (Exception e)
                {
                    return new StudentRegisterRsponse  { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
