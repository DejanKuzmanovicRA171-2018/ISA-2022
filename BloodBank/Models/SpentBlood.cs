using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SpentBlood
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? TransfusionCenterId { get; set; }
        public TransfusionCenter? TransfusionCenter { get; set; }
        public string Type { get; set; } = string.Empty;
        public char Rh { get; set; }
        public DateTime DateOfExpenditure { get; set; }
    }
}
