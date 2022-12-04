using Microsoft.EntityFrameworkCore;
using Models;


namespace Repository.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-US52EC0\\SQLEXPRESS;Database=isadb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCAdmin>().HasKey(l => new { l.EmployeeId, l.TransfusionCenterId });
            modelBuilder.Entity<User>().HasIndex(u => u.PasswordHash).IsUnique();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RegUser> RegUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TransfusionCenter> TransfusionCenters { get; set; }
        public DbSet<TCAdmin> TCAdmins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }

}