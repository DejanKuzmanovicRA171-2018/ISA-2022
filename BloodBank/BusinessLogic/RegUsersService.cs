using BusinessLogic.Exceptions;
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
    public class RegUsersService : IRegUsersService
    {
        private readonly IRepositoryWrapper _repository;

        public RegUsersService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task Create(RegUser entity)
        {
            var regUser = await _repository.RegUser.GetRegUser(ru => ru.UserID == entity.UserID);
            if (regUser is not null)
                throw new BusinessException($"Registered User with UserID: {entity.UserID} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.RegUser.CreateRegUser(entity);
            await _repository.Save();
        }

        public async void Delete(RegUser entity)
        {
            var regUser = await _repository.RegUser.GetRegUser(ru => ru.UserID == entity.UserID);
            if (regUser is null)
                throw new BusinessException("[Delete] Registered User doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.RegUser.DeleteRegUser(entity);
            await _repository.Save();
        }

        public async Task<RegUser> Get(Expression<Func<RegUser, bool>> expression)
        {
            var regUser = await _repository.RegUser.GetRegUser(expression);
            if (regUser is null)
                throw new BusinessException("Registered User not found", System.Net.HttpStatusCode.NotFound);
            return regUser;
        }

        public async Task<IEnumerable<RegUser>> GetAll()
        {
            return await _repository.RegUser.GetAllRegUsersAsync();
        }

        public async void Update(RegUser entity)
        {
            var regUser = await _repository.RegUser.GetRegUser(ru => ru.UserID == entity.UserID);
            if (regUser is null)
                throw new BusinessException("[Update] Registered User doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.RegUser.UpdateRegUser(entity);
            await _repository.Save();
        }
    }
}
