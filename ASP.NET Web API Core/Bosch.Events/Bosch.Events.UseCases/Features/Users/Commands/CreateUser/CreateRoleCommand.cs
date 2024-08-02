using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<int>
    {
        public InsertUserDto User { get; set; }
    }
}
