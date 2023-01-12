using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class AppointmentDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [Range(0, 90)]
        public int Duration { get; set; }
    }
}
