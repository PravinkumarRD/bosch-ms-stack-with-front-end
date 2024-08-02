using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand:IRequest<int>
    {
        public InsertRoleDto Role { get; set; }
    }
}
