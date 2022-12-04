using Models;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IAdminRepository : IRepositoryBase<Admin>
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdmin(Expression<Func<Admin, bool>> expression);
        Task CreateAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}
