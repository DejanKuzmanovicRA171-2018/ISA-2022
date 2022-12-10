using Models;
using System.Linq.Expressions;

namespace BusinessLogic.Interfaces
{
    public interface IBloodService : IBaseService<UnitOfBlood>
    {
        Task<IEnumerable<UnitOfBlood>> GetMultiple(Expression<Func<UnitOfBlood, bool>> expression);
    }
}
