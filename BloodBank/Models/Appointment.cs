using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime DateTime { get; set; }
        [Range(0, 90)]
        public int Duration { get; set; }
        public bool IsAvailable { get; set; }
    }
}
