using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
            //return await _context.Users.FindAsync(Id);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
