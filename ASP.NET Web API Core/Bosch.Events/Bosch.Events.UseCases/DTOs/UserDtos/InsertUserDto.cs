namespace Bosch.Events.UseCases.DTOs.UserDtos
{
    public class InsertUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
