using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public class BloodRepository : RepositoryBase<UnitOfBlood>, IBloodRepository
    {
        public BloodRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateUnitOfBlood(UnitOfBlood unitOfBlood)
        {
            await Create(unitOfBlood);
        }

        public void DeleteUnitOfBlood(UnitOfBlood unitOfBlood)
        {
            Delete(unitOfBlood);
        }

        public async Task<IEnumerable<UnitOfBlood>> GetAllBloodAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<UnitOfBlood> GetUnitOfBlood(Expression<Func<UnitOfBlood, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<UnitOfBlood>> GetUnitsOfBlood(Expression<Func<UnitOfBlood, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }

        public void UpdateUnitOfBlood(UnitOfBlood unitOfBlood)
        {
            Update(unitOfBlood);
        }
    }
}
