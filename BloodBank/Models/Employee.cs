namespace Models
{
    //Administrator centra i medicinsko osoblje
    public class Employee
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
