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
    public class VerifySchoolIdentifierQuery : IRequest<VerifySchoolIdentifierResponse>
    {
        public string Identifier { get; set; }

        public class VerifySchoolIdentifierQueryHandler : IRequestHandler<VerifySchoolIdentifierQuery, VerifySchoolIdentifierResponse>
        {
            private readonly ISchoolRepository schoolRepository;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public VerifySchoolIdentifierQueryHandler(ISchoolRepository schoolRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<VerifySchoolIdentifierResponse> Handle(VerifySchoolIdentifierQuery query, CancellationToken cancellationToken)
            {


                try
                {
                    return await schoolRepository.Verify(query.Identifier);
                    
                }
                catch (EntityNotFoundException ex)
                {

                    return new VerifySchoolIdentifierResponse
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                }
                catch (AppException ex)
                {

                    return new VerifySchoolIdentifierResponse
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };

                }
                catch (Exception e)
                {
                    return new VerifySchoolIdentifierResponse
                    {
                        IsSuccess = false,
                        Message = e.Message,
                    };
                }

            }

        }
    }
}
