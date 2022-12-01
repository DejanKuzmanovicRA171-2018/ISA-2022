using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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
            optionsBuilder.UseSqlServer("Server=DESKTOP-US52EC0\\SQLEXPRESS;Database=usersdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCAdmin>().HasKey(l => new { l.EmployeeId, l.TransfusionCenterId });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TCAdmin> RegUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TransfusionCenter> TransfusionCenters { get; set; }
        public DbSet<TCAdmin> TCAdmins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }

}