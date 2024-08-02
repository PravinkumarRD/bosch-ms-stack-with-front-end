using Bosch.Events.UseCases.DTOs.UserDtos;

namespace Bosch.Events.Api.Jwt
{
    public interface ITokenManager
    {
        string GenerateToken(UserDto user,string roleName);
    }
}
