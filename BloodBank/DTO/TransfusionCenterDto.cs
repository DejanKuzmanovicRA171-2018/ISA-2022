using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class TransfusionCenterDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(0, 5)]
        public float Rating { get; set; }
    }
}
