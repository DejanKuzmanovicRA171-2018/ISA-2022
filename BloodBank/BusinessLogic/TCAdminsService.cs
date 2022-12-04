using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

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
            var tcAdmin = await _repository.TCAdmin.GetTCAdmin(tca => tca.EmployeeId == entity.EmployeeId
                                                            && tca.TransfusionCenterId == entity.TransfusionCenterId);
            if (tcAdmin is not null)
                throw new BusinessException($"Transfusion Center Administrator with ID: {entity.EmployeeId} of TC with ID: " +
                                            $"{entity.TransfusionCenterId} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.TCAdmin.CreateTCAdmin(entity);
            await _repository.Save();
        }

        public async void Delete(TCAdmin entity)
        {
            var tcAdmin = await _repository.TCAdmin.GetTCAdmin(tca => tca.EmployeeId == entity.EmployeeId
                                                && tca.TransfusionCenterId == entity.TransfusionCenterId);
            if (tcAdmin is null)
                throw new BusinessException($"[Delete] Transfusion Center Administrator with ID: {entity.EmployeeId} of TC with ID: " +
                                            $"{entity.TransfusionCenterId} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.TCAdmin.Delete(entity);
            await _repository.Save();
        }

        public async Task<TCAdmin> Get(Expression<Func<TCAdmin, bool>> expression)
        {
            var tcAdmin = await _repository.TCAdmin.GetTCAdmin(expression);
            if (tcAdmin is null)
                throw new BusinessException("Transfusion Center Administrator doesn't exist", System.Net.HttpStatusCode.NotFound);
            return tcAdmin;
        }

        public async Task<IEnumerable<TCAdmin>> GetAll()
        {
            return await _repository.TCAdmin.GetAllTCAdminsAsync();
        }

        public async void Update(TCAdmin entity)
        {
            var tcAdmin = await _repository.TCAdmin.GetTCAdmin(tca => tca.EmployeeId == entity.EmployeeId
                                    && tca.TransfusionCenterId == entity.TransfusionCenterId);
            if (tcAdmin is null)
                throw new BusinessException($"[Update] Transfusion Center Administrator with ID: {entity.EmployeeId} of TC with ID: " +
                                            $"{entity.TransfusionCenterId} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.TCAdmin.UpdateTCAdmin(entity);
            await _repository.Save();
        }
    }
}
