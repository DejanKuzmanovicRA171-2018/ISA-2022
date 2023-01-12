using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

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
            var transfusionCenter = await _repository.TransfusionCenter.GetTC(tc => tc.Name == entity.Name);
            if (transfusionCenter is not null)
                throw new BusinessException($"Transfusion Center with name: {entity.Name} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.TransfusionCenter.CreateTC(entity);
            await _repository.Save();
        }

        public async Task Delete(TransfusionCenter entity)
        {
            var transfusionCenter = await _repository.TransfusionCenter.GetTC(tc => tc.Name == entity.Name);
            if (transfusionCenter is null)
                throw new BusinessException($"[Delete] Transfusion Center with name: {entity.Name} doesn't exists", System.Net.HttpStatusCode.BadRequest);
            _repository.TransfusionCenter.DeleteTC(transfusionCenter);
            await _repository.Save();
        }

        public async Task<TransfusionCenter> Get(Expression<Func<TransfusionCenter, bool>> expression)
        {
            var transfusionCenter = await _repository.TransfusionCenter.GetTC(expression);
            if (transfusionCenter is null)
                throw new BusinessException("Transfusion Center doesn't exist", System.Net.HttpStatusCode.NotFound);
            return transfusionCenter;
        }

        public async Task<IEnumerable<TransfusionCenter>> GetAll()
        {
            return await _repository.TransfusionCenter.GetAllTCsAsync();
        }

        public async Task Update(TransfusionCenter entity)
        {
            var transfusionCenter = await _repository.TransfusionCenter.GetTC(tc => tc.Name == entity.Name);
            if (transfusionCenter is null)
                throw new BusinessException($"[Update] Transfusion Center with name: {entity.Name} doesn't exists", System.Net.HttpStatusCode.BadRequest);
            _repository.TransfusionCenter.UpdateTC(entity);
            await _repository.Save();
        }
    }
}
