namespace DTO
{
    public class RegUserUpdateDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Career { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.MinValue;
    }
}
