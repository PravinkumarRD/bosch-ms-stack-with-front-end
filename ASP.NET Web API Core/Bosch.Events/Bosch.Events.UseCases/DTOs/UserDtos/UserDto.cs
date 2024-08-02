namespace Bosch.Events.UseCases.DTOs.UserDtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
