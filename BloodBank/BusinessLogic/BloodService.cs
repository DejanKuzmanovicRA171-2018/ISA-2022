using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class BloodService : IBloodService
    {
        private readonly IRepositoryWrapper _repository;
        private string[] bloodTypes = { "A", "B", "AB", "O" };
        public BloodService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task Create(UnitOfBlood entity)
        {
            if (entity.Rh != '+' && entity.Rh != '-')
                throw new BusinessException("invalid rhesus factor", System.Net.HttpStatusCode.BadRequest);
            if (bloodTypes.Contains(entity.Type) == false)
                throw new BusinessException("invalid blood type", System.Net.HttpStatusCode.BadRequest);

            var transfusionCenter = await _repository.TransfusionCenter.GetTC(tc => tc.Id == entity.TransfusionCenterId);
            if (transfusionCenter is null)
                throw new BusinessException($"Transfusion Center with id: {entity.TransfusionCenterId} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            await _repository.Blood.CreateUnitOfBlood(entity);
            await _repository.Save();
        }

        public async Task Delete(UnitOfBlood entity)
        {
            var unitOfBlood = await _repository.Blood.GetUnitOfBlood(e => e.Id == entity.Id);
            if (unitOfBlood is null)
                throw new BusinessException("[Delete] Unit of blood doesn't exist", System.Net.HttpStatusCode.BadRequest);

            var spentBlood = new SpentBlood
            {
                DateOfExpenditure = DateTime.UtcNow,
                Type = entity.Type,
                Rh = entity.Rh,
                TransfusionCenterId = entity.TransfusionCenterId,
            };
            await _repository.SpentBlood.Create(spentBlood);
            _repository.Blood.Delete(entity);
            await _repository.Save();
        }

        public async Task<UnitOfBlood> Get(Expression<Func<UnitOfBlood, bool>> expression)
        {
            var unitOfBlood = await _repository.Blood.GetUnitOfBlood(expression);
            if (unitOfBlood is null)
                throw new BusinessException("Unit of blood with matching parameters doesn't exist", System.Net.HttpStatusCode.NotFound);
            unitOfBlood.TransfusionCenter = await _repository.TransfusionCenter.GetTC(tc => tc.Id == unitOfBlood.TransfusionCenterId);
            return unitOfBlood;
        }
        public async Task<IEnumerable<UnitOfBlood>> GetMultiple(Expression<Func<UnitOfBlood, bool>> expression)
        {
            return await _repository.Blood.GetUnitsOfBlood(expression);
        }

        public async Task<IEnumerable<UnitOfBlood>> GetAll()
        {
            return await _repository.Blood.GetAllBloodAsync();
        }

        public async Task Update(UnitOfBlood entity)
        {
            var unitOfBlood = await _repository.Blood.GetUnitOfBlood(e => e.Id == entity.Id);
            if (unitOfBlood is null)
                throw new BusinessException("[Update] Unit of blood doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Blood.Update(entity);
            await _repository.Save();
        }
    }
}
