using Microsoft.AspNetCore.Identity;

namespace Models
{
    //Administrator centra i medicinsko osoblje
    public class Employee
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int? TransfusionCenterId { get; set; }
        public TransfusionCenter? TransfusionCenter { get; set; }
    }
}
