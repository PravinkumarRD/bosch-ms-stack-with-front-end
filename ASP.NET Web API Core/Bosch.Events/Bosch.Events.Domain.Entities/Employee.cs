using System.ComponentModel.DataAnnotations;

namespace Bosch.Events.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is required field!")]
        [MaxLength(100)]
        public string? EmployeeName { get; set; }
        [Required(ErrorMessage = "Employee Address is required field!")]
        [MaxLength(400)]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Employee City is required field!")]
        [MaxLength(50)]
        public string? City { get; set; }
        [Required(ErrorMessage = "Employee Country is required field!")]
        [MaxLength(50)]
        public string? Country { get; set; }
        [Required(ErrorMessage = "Employee Contact No. is required field!")]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Employee Skillsets is required field!")]
        [MaxLength(200)]
        public string? Skillsets { get; set; }
        [MaxLength(100)]
        public string? Avatar { get; set; }
        [Required(ErrorMessage = "Employee Joining Date is required field!")]
        public DateTime JoiningDate { get; set; }
        [Required(ErrorMessage = "Employee Department is required field!")]
        [MaxLength(50)]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
