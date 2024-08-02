using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles
{
    //Query is a requirement
    //Query - is requesting for all/list of roles 
    public class GetAllRolesQuery:IRequest<List<RoleDto>>
    {
    }
}
