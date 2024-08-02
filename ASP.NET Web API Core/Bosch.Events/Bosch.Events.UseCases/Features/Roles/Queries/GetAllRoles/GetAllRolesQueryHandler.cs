using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles
{
    //Handler for the requirement
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        private readonly ICommonRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(ICommonRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<RoleDto>>(await _rolesRepository.GetAllAsync());
        }
    }
}
