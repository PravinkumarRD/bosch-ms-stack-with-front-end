using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.AuthenticateUser
{
    public class AuthenticateUserQuery:IRequest<UserDto>
    {
        public UserDto Credentials { get; set; }
    }
}
