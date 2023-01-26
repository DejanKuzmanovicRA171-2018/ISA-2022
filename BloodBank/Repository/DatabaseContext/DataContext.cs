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