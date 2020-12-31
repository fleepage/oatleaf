using AutoMapper;
using fleepage.oatleaf.com.Commands.Dto;
using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands
{
    public class EnableFreelanceCommand : IRequest<CreateSchoolResponse>
    {
        public CreateSchoolDto schoolDto { get; set; }

        public class EnableFreelanceCommandHandler : IRequestHandler<EnableFreelanceCommand, CreateSchoolResponse>
        {
            private readonly ISchoolRepository schoolRepository;
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IAccountRepository accountRepository;
            private readonly IFreelanceRepository freelanceRepository;
            private readonly IMapper mapper;

            public EnableFreelanceCommandHandler(ISchoolRepository schoolRepository, IFreelanceRepository freelanceRepository , IAccountRepository accountRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.freelanceRepository = freelanceRepository ?? throw new ArgumentNullException(nameof(freelanceRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateSchoolResponse> Handle(EnableFreelanceCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    var schools = mapper.Map<School>(request.schoolDto);
                    var result = await schoolRepository.Create(schools);

                    if (result.IsSuccess)
                    {
                        var account = await accountRepository.ActivateAccount(new Accounts { Role = "Freelance", isActive = true, UserId = request.schoolDto.User });
                        var adminResult = await freelanceRepository.Add(new Freelance { AccountsId = account.Id, UserId = request.schoolDto.User, SchoolId = result.SchoolId });

                        if (adminResult?.Id > 0)
                        {
                            var permissions = new List<Permissions> {
                    new Permissions{
                    Permission="work",
                    Level="rw",
                    SchoolAdminId = adminResult.Id

                    },
                    new Permissions{
                    Permission="tools",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                                        new Permissions{
                    Permission="student",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="assessment",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="media",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="event",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="financials",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="staff",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="parent",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="settings",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="media",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="event",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="store",
                    Level="rw",
                    SchoolAdminId = adminResult.Id
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
                    }

                    return result;
                }
                catch (Exception e)
                {
                    return new CreateSchoolResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
