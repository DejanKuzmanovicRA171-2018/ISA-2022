using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository.DatabaseContext
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer("Server=DESKTOP-US52EC0\\SQLEXPRESS;Database=isadb;Trusted_Connection=true;TrustServerCertificate=true;");
            return new DataContext(builder.Options);
        }
    }
}
