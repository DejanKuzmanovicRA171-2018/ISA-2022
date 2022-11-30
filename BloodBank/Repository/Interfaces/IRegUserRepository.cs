using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRegUserRepository : IRepositoryBase<RegUser>
    {
        Task<IEnumerable<RegUser>> GetAllRegUsersAsync();
        Task<RegUser> GetRegUser(Expression<Func<RegUser, bool>> expression);
        Task CreateRegUser(RegUser user);
        void UpdateRegUser(RegUser user);
        void DeleteRegUser(RegUser user);
    }
}
