using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class EmployeeRegDto
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
            ErrorMessage = "Passwords must be at between 8 and 15 characters and contain at least 1 lower and upper case letter, a number and a special character")]
        public string Password { get; set; } = string.Empty;
        public string TransfusionCenterName { get; set; } = string.Empty;
    }
}
