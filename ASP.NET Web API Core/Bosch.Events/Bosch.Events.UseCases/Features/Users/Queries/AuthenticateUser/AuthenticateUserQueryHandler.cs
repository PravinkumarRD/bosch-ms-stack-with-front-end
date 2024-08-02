using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.AuthenticateUser
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IBoschAuthenticator _authenticator;

        public AuthenticateUserQueryHandler(IMapper mapper, IBoschAuthenticator authenticator)
        {
            _mapper = mapper;
            _authenticator = authenticator;
        }

        public async Task<UserDto> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.Credentials);
            return _mapper.Map<UserDto>(await _authenticator.Authenticate(user));
        }
    }
}
