using Models;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IBloodRepository : IRepositoryBase<UnitOfBlood>
    {
        Task<IEnumerable<UnitOfBlood>> GetAllBloodAsync();
        Task<UnitOfBlood> GetUnitOfBlood(Expression<Func<UnitOfBlood, bool>> expression);
        Task<IEnumerable<UnitOfBlood>> GetUnitsOfBlood(Expression<Func<UnitOfBlood, bool>> expression);
        Task CreateUnitOfBlood(UnitOfBlood unitOfBlood);
        void UpdateUnitOfBlood(UnitOfBlood unitOfBlood);
        void DeleteUnitOfBlood(UnitOfBlood unitOfBlood);
    }
}
