using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDto
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
            ErrorMessage = "Passwords must be at between 8 and 15 characters and contain at least 1 lower and upper case letter, a number and a special character")]
        public string Password { get; set; } = string.Empty;
    }
}