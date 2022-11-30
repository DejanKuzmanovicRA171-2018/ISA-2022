using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Repository
{
    public class TransfusionCenterRepository : RepositoryBase<TransfusionCenter>, ITransfusionCenterRepository
    {
        public TransfusionCenterRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateTC(TransfusionCenter tc)
        {
            await Create(tc);
        }

        public void DeleteTC(TransfusionCenter tc)
        {
            Delete(tc);
        }

        public async Task<IEnumerable<TransfusionCenter>> GetAllTCsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<TransfusionCenter> GetTC(Expression<Func<TransfusionCenter, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public void UpdateTC(TransfusionCenter tc)
        {
            Update(tc);
        }

    }
}
