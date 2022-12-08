using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class RegUsersService : IRegUsersService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IRegUserRepository _regUserRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public RegUsersService(IRepositoryWrapper repository, IRegUserRepository regUserRepository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _regUserRepository = regUserRepository;
            _userManager = userManager;
        }

        public async Task Create(RegUser entity)
        {
            var regUser = await _repository.RegUser.GetRegUser(ru => ru.UserID == entity.UserID);
            if (regUser is not null)
                throw new BusinessException($"Registered User with UserID: {entity.UserID} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.RegUser.CreateRegUser(entity);
            await _repository.Save();
        }

        public async Task Delete(RegUser entity)
        {
            var user = await _userManager.FindByIdAsync(entity.UserID);
            if (user is null)
                throw new BusinessException("User doesn't exist", System.Net.HttpStatusCode.InternalServerError);

            var regUser = await _repository.RegUser.GetRegUser(ru => ru.UserID == entity.UserID);
            if (regUser is null)
                throw new BusinessException("[Delete] Registered User doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.RegUser.DeleteRegUser(entity);
            await _userManager.DeleteAsync(user);
            await _repository.Save();
        }

        public async Task<RegUser> Get(Expression<Func<RegUser, bool>> expression)
        {
            var regUser = await _repository.RegUser.GetRegUser(expression);
            if (regUser is null)
                throw new BusinessException("Registered User not found", System.Net.HttpStatusCode.NotFound);
            regUser.User = await _userManager.FindByIdAsync(regUser.UserID);
            return regUser;
        }

        public async Task<IEnumerable<RegUser>> GetAll()
        {
            return await _repository.RegUser.GetAllRegUsersAsync();
        }

        public async Task Update(RegUser entity)
        {
            var regUser = await _repository.RegUser.GetRegUser(ru => ru.UserID == entity.UserID);
            if (regUser is null)
                throw new BusinessException("[Update] Registered User doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.RegUser.UpdateRegUser(entity);
            await _repository.Save();
        }
    }
}
