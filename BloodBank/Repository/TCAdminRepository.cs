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
    public class TCAdminRepository : RepositoryBase<TCAdmin>, ITCAdminRepository
    {
        public TCAdminRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateTCAdmin(TCAdmin tcAdmin)
        {
            await Create(tcAdmin);
        }

        public void DeleteTCAdmin(TCAdmin tcAdmin)
        {
            Delete(tcAdmin);
        }

        public async Task<IEnumerable<TCAdmin>> GetAllTCAdminsAsync()
        {
           return await FindAll().ToListAsync();
        }

        public async Task<TCAdmin> GetTCAdmin(Expression<Func<TCAdmin, bool>> expression)
        {
           return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public void UpdateTCAdmin(TCAdmin tcAdmin)
        {
            Update(tcAdmin);
        }
    }
}
