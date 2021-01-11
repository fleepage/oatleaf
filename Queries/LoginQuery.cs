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
    public class LoginQuery : IRequest<LoginQueryDto>
    {
        public AuthenticateDto authenticateDto { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryDto>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<LoginQueryDto> Handle(LoginQuery query, CancellationToken cancellationToken)
            {


                try {
                    var user = await userRepository.Authenticate(query.authenticateDto);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.Id.ToString()), }),
                        
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return new LoginQueryDto {
                        IsSuccess = true,
                        UserDto = new UserDto {
                            Id = user.Id,
                            Phone = user.Phone,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            OtherNames = user.OtherNames,
                            Username = user.Username,
                            TempPassword = user.TempPassword,
                            //Accounts = mapper.Map<ICollection<AccountDto>>(user.Accounts),
                            Token = tokenString
                        }
                    };
                }
                catch (EntityNotFoundException ex)
                {

                    return new LoginQueryDto
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                        UserDto = null,



                    };
                }
                catch (AppException ex)
                {

                    return new LoginQueryDto
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                        UserDto = null,



                    };

                }
                catch (Exception e) {
                    return new LoginQueryDto
                    {
                        IsSuccess = false,
                        Message = e.Message,
                        UserDto = null,
                        
                        

                    };
                }

            }

        }
    }
}
