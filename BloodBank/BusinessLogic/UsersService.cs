using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class UsersService : IUsersService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersService(IRepositoryWrapper repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task Create(IdentityUser entity, string password)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email);
            if (user is not null)
                throw new BusinessException($"User with email: {entity.Email} already exists", System.Net.HttpStatusCode.BadRequest);
            await _userManager.CreateAsync(entity, password);
        }

        public Task Create(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(IdentityUser entity)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email);
            if (user is null)
                throw new BusinessException($"[Delete] User with email: {entity.Email} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            await _userManager.DeleteAsync(entity);
        }

        public Task<IdentityUser> Get(Expression<Func<IdentityUser, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public async Task<IdentityUser> GetUser(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }
        //public async Task<User> Get(Expression<Func<IdentityUser, bool>> expression)
        //{
        //    var user = await _userManager.Find
        //    if (user is null)
        //        throw new BusinessException("User with doesn't exist", System.Net.HttpStatusCode.NotFound);
        //    return user;
        //}

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task Update(IdentityUser entity)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email);
            if (user is null)
                throw new BusinessException($"[Update] User with email: {entity.Email} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            await _userManager.UpdateAsync(entity);
        }
    }
}