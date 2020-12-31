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
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public UserRegisterDto registerDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {

                try {
                    var user = mapper.Map<User>(request.registerDto);
                    var result = await userRepository.Register(user, request.registerDto.Password, request.registerDto.PasswordConfirmation, "user");
                    return result;
                }
                catch (Exception e) {
                    return new CreateUserResponse { IsSuccess = false, Message = e.Message };

                }

            }


        }
    }
}
