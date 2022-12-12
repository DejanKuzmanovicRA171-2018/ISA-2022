using Models;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface ISpentBloodRepository : IRepositoryBase<SpentBlood>
    {
        Task<IEnumerable<SpentBlood>> GetAllBloodAsync();
        Task<SpentBlood> GetUnitOfBlood(Expression<Func<SpentBlood, bool>> expression);
        Task<IEnumerable<SpentBlood>> GetUnitsOfBlood(Expression<Func<SpentBlood, bool>> expression);
        Task CreateUnitOfBlood(SpentBlood spentBlood);
        void UpdateUnitOfBlood(SpentBlood spentBlood);
        void DeleteUnitOfBlood(SpentBlood spentBlood);
    }
}
