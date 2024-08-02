using System.ComponentModel.DataAnnotations;

namespace FirstCtrlWebApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Contact Name is a required field!")]
        [MaxLength(10,ErrorMessage ="Contact name should no exceed 10 characters!")]
        public string ContactName { get; set; } = string.Empty;
        [Required(ErrorMessage = "City is a required field!")]
        [MaxLength(10, ErrorMessage = "City name should no exceed 10 characters!")]
        public string City { get; set; } = string.Empty;
    }
}
