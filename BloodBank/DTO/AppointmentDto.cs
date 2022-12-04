using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class AppointmentDto
    {
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [Range(0, 90)]
        public int Duration { get; set; }
    }
}
