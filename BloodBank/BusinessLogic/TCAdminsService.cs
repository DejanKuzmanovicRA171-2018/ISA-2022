using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TCAdminsService : ITCAdminsService
    {
        private readonly IRepositoryWrapper _repository;
        public TCAdminsService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task Create(TCAdmin entity)
        {
            await _repository.TCAdmin.Create(entity);
        }

        public void Delete(TCAdmin entity)
        {
            _repository.TCAdmin.Delete(entity);
        }

        public async Task<TCAdmin> Get(Expression<Func<TCAdmin, bool>> expression)
        {
            return await _repository.TCAdmin.GetTCAdmin(expression);
        }

        public async Task<IEnumerable<TCAdmin>> GetAll()
        {
            return await _repository.TCAdmin.GetAllTCAdminsAsync();
        }

        public void Update(TCAdmin entity)
        {
            _repository.TCAdmin.UpdateTCAdmin(entity);
        }
    }
}
