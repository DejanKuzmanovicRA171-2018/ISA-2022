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
    public class RegUserRepository : RepositoryBase<RegUser>, IRegUserRepository
    {
        public RegUserRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateRegUser(RegUser user)
        {
            await _context.AddAsync(user);
        }

        public void DeleteRegUser(RegUser user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<RegUser>> GetAllRegUsersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<RegUser> GetRegUser(Expression<Func<RegUser, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public void UpdateRegUser(RegUser user)
        {
            Update(user);
        }
    }
}
