using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public class SpentBloodRepository : RepositoryBase<SpentBlood>, ISpentBloodRepository
    {
        public SpentBloodRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateUnitOfBlood(SpentBlood spentBlood)
        {
            await Create(spentBlood);
        }

        public void DeleteUnitOfBlood(SpentBlood spentBlood)
        {
            Delete(spentBlood);
        }

        public async Task<IEnumerable<SpentBlood>> GetAllBloodAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<SpentBlood> GetUnitOfBlood(Expression<Func<SpentBlood, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<SpentBlood>> GetUnitsOfBlood(Expression<Func<SpentBlood, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }

        public void UpdateUnitOfBlood(SpentBlood spentBlood)
        {
            Update(spentBlood);
        }
    }
}
