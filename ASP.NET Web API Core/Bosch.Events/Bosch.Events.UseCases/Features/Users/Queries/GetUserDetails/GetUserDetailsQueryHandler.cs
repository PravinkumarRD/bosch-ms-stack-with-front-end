using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        private readonly ICommonRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public GetUserDetailsQueryHandler(ICommonRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetDetailsAsync(request.UserId));
        }
    }
}
