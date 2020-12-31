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
    public class CreateOrganisationCommand : IRequest<CreateOrganisationResponse>
    {
        public CreateOrganisationDto organisationDto { get; set; }

        public class CreateOrganisationCommandHandler : IRequestHandler<CreateOrganisationCommand, CreateOrganisationResponse>
        {
            private readonly IOrganisationRepository organisationRepository;
            private readonly IGenericRepository<Permissions> permissionRepository;
            private readonly IGenericRepository<Accounts> accountRepository;
            private readonly IGenericRepository<OrgAdmin> OrgAdminRepository;
            private readonly IMapper mapper;

            public CreateOrganisationCommandHandler(IOrganisationRepository organisationRepository, IGenericRepository<OrgAdmin> OrgAdminRepository, IGenericRepository<Accounts> accountRepository, IGenericRepository<Permissions> permissionRepository, IMapper mapper)
            {
                this.organisationRepository = organisationRepository ?? throw new ArgumentNullException(nameof(organisationRepository));
                this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
                this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
                this.OrgAdminRepository = OrgAdminRepository ?? throw new ArgumentNullException(nameof(OrgAdminRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateOrganisationResponse> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    var organisation = mapper.Map<Organisation>(request.organisationDto);
                    var result = await organisationRepository.Create(organisation);

                    if (result.IsSuccess)
                    {
                        var account = await accountRepository.Add(new Accounts { Role = "OrgAdmin", isActive = true, UserId = request.organisationDto.User });
                        var adminResult = await OrgAdminRepository.Add(new OrgAdmin { AccountsId = account.Id, UserId = request.organisationDto.User, OrganisationId = result.OrganisationId });

                        if (adminResult?.Id > 0)
                        {
                            var permissions = new List<Permissions> {
                    new Permissions{
                    Permission="work",
                    Level="rw",
                    OrgAdminId = adminResult.Id

                    },
                    new Permissions{
                    Permission="tools",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                                        new Permissions{
                    Permission="student",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="assessment",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="media",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="event",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="financials",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="member",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="parent",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="settings",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="media",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="event",
                    Level="rw",
                    OrgAdminId = adminResult.Id
                    },
                    new Permissions{
                    Permission="store",
                    Level="rw",
                    OrgAdminId = adminResult.Id
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
                    return new CreateOrganisationResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
