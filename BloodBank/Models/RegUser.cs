using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    //Registrovani korisnik
    public class RegUser
    {
        public int Id { get; set; }
        public string? UserID { get; set; }
        public IdentityUser? User { get; set; }
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string JMBG { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Career { get; set; } = string.Empty;
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int Weight { get; set; } = 0;
        public int Height { get; set; } = 0;
    }
}
