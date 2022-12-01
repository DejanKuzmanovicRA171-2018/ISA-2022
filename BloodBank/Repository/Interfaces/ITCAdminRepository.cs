using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITCAdminRepository : IRepositoryBase<TCAdmin>
    {
        Task<IEnumerable<TCAdmin>> GetAllTCAdminsAsync();
        Task<TCAdmin> GetTCAdmin(Expression<Func<TCAdmin, bool>> expression);
        Task CreateTCAdmin(TCAdmin tcAdmin);
        void UpdateTCAdmin(TCAdmin tcAdmin);
        void DeleteTCAdmin(TCAdmin tcAdmin);
    }
}
