using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateAdmin(Admin admin)
        {
            await Create(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            Delete(admin);
        }

        public async Task<Admin> GetAdmin(Expression<Func<Admin, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public void UpdateAdmin(Admin admin)
        {
            Update(admin);
        }
    }
}
