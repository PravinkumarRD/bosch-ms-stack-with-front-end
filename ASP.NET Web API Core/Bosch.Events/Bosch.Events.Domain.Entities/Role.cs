using System.ComponentModel.DataAnnotations;

namespace Bosch.Events.Domain.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(20, ErrorMessage = "Role name can not exceed 20 characters!")]
        public string? RoleName { get; set; }
        [MaxLength(100, ErrorMessage = "Role description can not exceed 100 characters!")]
        public string? RoleDescription { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
