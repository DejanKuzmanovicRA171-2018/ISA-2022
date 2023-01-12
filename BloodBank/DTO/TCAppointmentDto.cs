using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class TCAppointmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(0, 5)]
        public float Rating { get; set; }
        public int AppointmentId { get; set; }
    }
}
