using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.GetAllUsers
{
    //Handler for the requirement
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly ICommonRepository<User> _usersRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(ICommonRepository<User> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<UserDto>>(await _usersRepository.GetAllAsync());
        }
    }
}
