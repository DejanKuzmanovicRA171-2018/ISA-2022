using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TransfusionCentersService : ITransfusionCentersService
    {
        private readonly IRepositoryWrapper _repository;
        public TransfusionCentersService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task Create(TransfusionCenter entity)
        {
            await _repository.TransfusionCenter.CreateTC(entity);
            await _repository.Save();
        }

        public void Delete(TransfusionCenter entity)
        {
            _repository.TransfusionCenter.DeleteTC(entity);
            _repository.Save();
        }

        public async Task<TransfusionCenter> Get(Expression<Func<TransfusionCenter, bool>> expression)
        {
            return await _repository.TransfusionCenter.GetTC(expression);
        }

        public async Task<IEnumerable<TransfusionCenter>> GetAll()
        {
            return await _repository.TransfusionCenter.GetAllTCsAsync();
        }

        public void Update(TransfusionCenter entity)
        {
            _repository.TransfusionCenter.DeleteTC(entity);
            _repository.Save();
        }
    }
}
