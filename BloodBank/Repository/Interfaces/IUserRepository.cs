using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUser(Expression<Func<User, bool>> expression);
        Task CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

    }
}
