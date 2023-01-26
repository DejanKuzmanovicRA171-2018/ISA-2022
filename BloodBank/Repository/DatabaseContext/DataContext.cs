using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Repository.DatabaseContext
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-IGQCCKV\\SQLEXPRESS;Database=isadb;User ID=SA;Password=S3cur3P@ssW0rd!;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<TransfusionCenter>().HasData(
               new TransfusionCenter { Id = 1, Name = "Sudri", Address = "Njegoseva 31", Description = "Prelepa bolnica u centru Gradnulice", Rating = 5, Location = "Zrenjanin" },
               new TransfusionCenter { Id = 2, Name = "Sveti Jovan", Address = "Ive Lole Ribara 12", Description = "Preko puta divne picerije 'Saracena'", Rating = 4, Location = "Zrenjanin" },
               new TransfusionCenter { Id = 3, Name = "Dom Zdravlja 'Zvonimir Radulović'", Address = "Jevrejska 25b", Description = "Moderni dom zdravlja sa dugom tradicijom", Rating = 3, Location = "Novi Sad" },
               new TransfusionCenter { Id = 4, Name = "Institut za transfuziju krvi Beograd", Address = "Svetog Save 39", Description = "Vodeća, visoko specijalizovana naučno istraživačka i nastavna zdravstvena ustanova, referalna za oblast transfuziologije u Srbiji", Rating = 5, Location = "Beograd" },
               new TransfusionCenter { Id = 5, Name = "Poliklinika Obradović", Address = "Temerinska 20", Description = "Ljubazno i profesionalno osoblje koje Vas očekuje od prijemnog šaltera do lekara specijaliste koji vrši preglede, uz puno poštovanje Vaše ličnosti i razumevanje Vaših potreba i tegoba, je ono što nas već godinama čini prepoznatljivim, a sa tom tradicijom nastavlja se i u novootvorenoj bolnici “Poliklinika Obradović”.", Rating = 2, Location = "Pančevo" }
               );
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser { Id = "0f585944-59f6-4824-bea9-d64c24cbe934", UserName = "sibin.stojanovic@gmail.com", Email = "sibin.stojanovic@gmail.com", NormalizedEmail = "SIBIN.STOJANOVIC@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Sibin123!"), EmailConfirmed = true },
                new IdentityUser { Id = "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3", UserName = "lazar.markovic@gmail.com", Email = "lazar.markovic@gmail.com", NormalizedEmail = "LAZAR.MARKOVIC@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Lazar123!"), EmailConfirmed = true },
                new IdentityUser { Id = "aca6bea4-4ce0-4617-901b-a7f1474ebb1d", UserName = "ivan.lendjer@gmail.com", Email = "ivan.lendjer@gmail.com", NormalizedEmail = "IVAN.LENDJER@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Ivan123!"), EmailConfirmed = true },
                new IdentityUser { Id = "f028f3a7-a01e-49df-9e9c-3a25a51843ca", UserName = "novak.djokovic@gmail.com", Email = "novak.djokovic@gmail.com", NormalizedEmail = "NOVAK.DJOKOVIC@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Novak123!"), EmailConfirmed = true },
                new IdentityUser { Id = "d6c6300c-d516-4c79-8a82-b47ef6b4e37d", UserName = "blagoje.jevrosimov@gmail.com", Email = "blagoje.jevrosimov@gmail.com", NormalizedEmail = "BLAGOJE.JEVROSIMOV@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Blagoje123!"), EmailConfirmed = true },
                new IdentityUser { Id = "b49d90ea-e546-48df-a128-994a58354ccc", UserName = "nikola.rokvic@gmail.com", Email = "nikola.rokvic@gmail.com", NormalizedEmail = "NIKOLA.ROKVIC@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Nikola123!"), EmailConfirmed = true },
                new IdentityUser { Id = "f59199d7-3e1f-4d63-870d-688936b2523e", UserName = "ivana.mihajlovic@gmail.com", Email = "ivana.mihajlovic@gmail.com", NormalizedEmail = "IVANA.MIHAJLOVIC@GMAIL.COM", PasswordHash = hasher.HashPassword(null, "Ivana123!"), EmailConfirmed = true }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "f808309d-9564-4748-a469-46270826774e", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "0325c6cc-a303-4165-ad42-2c08d8516c91", Name = "RegUser", NormalizedName = "REGUSER" },
                new IdentityRole { Id = "f871b11d-ecad-4d67-9223-1f6d3cf684b1", Name = "Employee", NormalizedName = "EMPLOYEE" }
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "f808309d-9564-4748-a469-46270826774e", UserId = "0f585944-59f6-4824-bea9-d64c24cbe934" },
                new IdentityUserRole<string> { RoleId = "0325c6cc-a303-4165-ad42-2c08d8516c91", UserId = "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3" },
                new IdentityUserRole<string> { RoleId = "f871b11d-ecad-4d67-9223-1f6d3cf684b1", UserId = "aca6bea4-4ce0-4617-901b-a7f1474ebb1d" },
                new IdentityUserRole<string> { RoleId = "f871b11d-ecad-4d67-9223-1f6d3cf684b1", UserId = "f028f3a7-a01e-49df-9e9c-3a25a51843ca" },
                new IdentityUserRole<string> { RoleId = "f871b11d-ecad-4d67-9223-1f6d3cf684b1", UserId = "d6c6300c-d516-4c79-8a82-b47ef6b4e37d" },
                new IdentityUserRole<string> { RoleId = "f871b11d-ecad-4d67-9223-1f6d3cf684b1", UserId = "b49d90ea-e546-48df-a128-994a58354ccc" },
                new IdentityUserRole<string> { RoleId = "f871b11d-ecad-4d67-9223-1f6d3cf684b1", UserId = "f59199d7-3e1f-4d63-870d-688936b2523e" }
                );
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, UserId = "0f585944-59f6-4824-bea9-d64c24cbe934" }
                );
            modelBuilder.Entity<RegUser>().HasData(
                new RegUser { Id = 1, UserID = "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3", Address = "Miletićeva 12", BirthDate = new DateTime(1973, 5, 11), City = "Beograd", Career = "Arhitekta", JMBG = "1105973850123", CompanyName = "Jadran d.o.o Beograd", FirstName = "Lazar", LastName = "Markovic", Gender = "male", PhoneNumber = "0623088513", Country = "Srbija" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, TransfusionCenterId = 2, UserId = "aca6bea4-4ce0-4617-901b-a7f1474ebb1d" },
                new Employee { Id = 2, TransfusionCenterId = 4, UserId = "f028f3a7-a01e-49df-9e9c-3a25a51843ca" },
                new Employee { Id = 3, TransfusionCenterId = 1, UserId = "d6c6300c-d516-4c79-8a82-b47ef6b4e37d" },
                new Employee { Id = 4, TransfusionCenterId = 3, UserId = "b49d90ea-e546-48df-a128-994a58354ccc" },
                new Employee { Id = 5, TransfusionCenterId = 5, UserId = "f59199d7-3e1f-4d63-870d-688936b2523e" }
                );
            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 1, DateOfSubmition = new DateTime(2023, 1, 25, 15, 0, 0), FirstName = "Lazar", LastName = "Markovic", JMBG = "1105973850123", Gender = "male", PhoneNumber = "0623088513", Location = "Beograd", ResidenceAddress = "Miletićeva 12", NumberOfPreviousDonations = 0, Q1 = false, Q2 = false, Q3 = false, Q4 = false, Q5 = false, Q6 = false, Q7 = false, Q8 = false, Q9 = false, Q10 = false, Q11 = false, Q12 = false, Q13 = false, Q14 = false, Q15 = false, Q16 = false, Q17 = false, Q18 = false, Q19 = false, Q20 = false, Q21 = false, Q22 = false, Q23 = false, }
                );
            modelBuilder.Entity<Appointment>().HasData(
                 new Appointment { Id = 1, EmployeeId = 1, TransfusionCenterId = 2, DateTime = new DateTime(2023, 2, 2, 9, 0, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 2, EmployeeId = 1, TransfusionCenterId = 2, DateTime = new DateTime(2023, 2, 2, 9, 30, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 3, EmployeeId = 1, TransfusionCenterId = 2, DateTime = new DateTime(2023, 2, 2, 10, 0, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 4, EmployeeId = 1, TransfusionCenterId = 2, DateTime = new DateTime(2023, 1, 15, 9, 0, 0), Duration = 30, IsAvailable = false, RegUserId = 1 },
                 new Appointment { Id = 5, EmployeeId = 1, TransfusionCenterId = 2, DateTime = new DateTime(2023, 1, 20, 19, 0, 0), Duration = 25, IsAvailable = false, RegUserId = 1 },
                 new Appointment { Id = 6, EmployeeId = 1, TransfusionCenterId = 2, DateTime = new DateTime(2023, 2, 6, 15, 30, 0), Duration = 15, IsAvailable = true },
                 new Appointment { Id = 7, EmployeeId = 2, TransfusionCenterId = 4, DateTime = new DateTime(2023, 2, 2, 9, 0, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 8, EmployeeId = 2, TransfusionCenterId = 4, DateTime = new DateTime(2023, 12, 2, 12, 0, 0), Duration = 30, IsAvailable = false, RegUserId = 1 },
                 new Appointment { Id = 9, EmployeeId = 2, TransfusionCenterId = 4, DateTime = new DateTime(2023, 5, 8, 11, 0, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 10, EmployeeId = 3, TransfusionCenterId = 1, DateTime = new DateTime(2023, 2, 2, 9, 0, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 11, EmployeeId = 4, TransfusionCenterId = 3, DateTime = new DateTime(2023, 2, 2, 9, 0, 0), Duration = 30, IsAvailable = true },
                 new Appointment { Id = 12, EmployeeId = 5, TransfusionCenterId = 5, DateTime = new DateTime(2023, 2, 2, 9, 0, 0), Duration = 30, IsAvailable = true }
                 );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<RegUser> RegUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TransfusionCenter> TransfusionCenters { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UnitOfBlood> Blood { get; set; }
        public DbSet<SpentBlood> SpentBlood { get; set; }
        public DbSet<Survey> Surveys { get; set; }
    }

}