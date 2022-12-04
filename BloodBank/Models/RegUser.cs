﻿namespace Models
{
    //Registrovani korisnik
    public class RegUser
    {
        public int Id { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
