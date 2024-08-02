using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, RoleDto>
    {
        private readonly ICommonRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;
        public GetUserDetailsQueryHandler(ICommonRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<RoleDto> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoleDto>(await _rolesRepository.GetDetailsAsync(request.RoleId));
        }
    }
}
