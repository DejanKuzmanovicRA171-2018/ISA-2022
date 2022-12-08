using Microsoft.AspNetCore.Identity;

namespace Models
{
    //Administrator sistema
    public class Admin
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

    }
}
