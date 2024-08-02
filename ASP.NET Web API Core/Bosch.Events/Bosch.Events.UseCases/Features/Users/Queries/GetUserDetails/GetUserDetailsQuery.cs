using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery:IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
