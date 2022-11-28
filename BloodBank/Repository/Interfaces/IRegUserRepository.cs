using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRegUserRepository : IRepositoryBase<RegUser>
    {
        Task<IEnumerable<RegUser>> GetAllUsersAsync();
        Task<RegUser> GetUser(int Id);
        Task CreateUser(RegUser user);
        void UpdateUser(RegUser user);
        void DeleteUser(RegUser user);
    }
}
