using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TCAdmin
    {
        [Key, Column(Order = 0)]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Key, Column(Order = 1)]
        public int? TransfusionCenterId { get; set; }
        public TransfusionCenter? TransfusionCenter { get; set; }
    }
}
