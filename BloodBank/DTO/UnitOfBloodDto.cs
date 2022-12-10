using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UnitOfBloodDto
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public char Rh { get; set; }
        [Required]
        public int TransfusionCenterId { get; set; }
    }
}
