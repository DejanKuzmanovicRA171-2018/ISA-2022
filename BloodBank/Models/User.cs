using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; } 

        public string Role { get; set; } = string.Empty;

    }
}