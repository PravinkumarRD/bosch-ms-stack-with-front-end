using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly ICommonRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;
        public CreateRoleCommandHandler(ICommonRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var newRole = _mapper.Map<Role>(request.Role);
            return _mapper.Map<int>(await _rolesRepository.InsertAsync(newRole));
        }
    }
}
