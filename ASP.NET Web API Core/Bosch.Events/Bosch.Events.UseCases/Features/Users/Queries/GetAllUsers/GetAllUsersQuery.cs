using Bosch.Events.UseCases.DTOs.RoleDtos;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.GetAllUsers
{
    //Query is a requirement
    //Query - is requesting for all/list of Users 
    public class GetAllUsersQuery:IRequest<List<UserDto>>
    {
    }
}
