namespace Bosch.Events.Domain.Entities
{
    public class AuthResponse
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string token { get; set; } = string.Empty;
    }
}
