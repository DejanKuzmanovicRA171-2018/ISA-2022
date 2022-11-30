using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITransfusionCenterRepository : IRepositoryBase<TransfusionCenter>
    {
        Task<IEnumerable<TransfusionCenter>> GetAllTCsAsync();
        Task<TransfusionCenter> GetTC(Expression<Func<TransfusionCenter, bool>> expression);
        Task CreateTC(TransfusionCenter tc);
        void UpdateTC(TransfusionCenter tc);
        void DeleteTC(TransfusionCenter tc);
    }
}
