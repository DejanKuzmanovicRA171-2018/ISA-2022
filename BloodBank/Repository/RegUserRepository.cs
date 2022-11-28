using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RegUserRepository : RepositoryBase<RegUser>, IRegUserRepository
    {
        public RegUserRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateUser(RegUser user)
        {
            await _context.AddAsync(user);
        }

        public void DeleteUser(RegUser user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<RegUser>> GetAllUsersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<RegUser> GetUser(int Id)
        {
            return await FindByCondition(user => user.Id == Id).FirstOrDefaultAsync();
        }

        public void UpdateUser(RegUser user)
        {
            Update(user);
        }
    }
}
