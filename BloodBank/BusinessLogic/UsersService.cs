using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class UsersService : IUsersService
    {
        private readonly IRepositoryWrapper _repository;

        public UsersService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task Create(User entity)
        {
            var user = await _repository.User.GetUser(u => u.Email == entity.Email);
            if (user is not null)
                throw new BusinessException($"User with name: {entity.Email} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.User.CreateUser(entity);
            await _repository.Save();
        }

        public async void Delete(User entity)
        {
            var user = await _repository.User.GetUser(u => u.Email == entity.Email);
            if (user is null)
                throw new BusinessException($"[Delete] User with name: {entity.Email} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.User.Delete(entity);
            await _repository.Save();
        }

        public async Task<User> Get(Expression<Func<User, bool>> expression)
        {
            var user = await _repository.User.GetUser(expression);
            if (user is null)
                throw new BusinessException("User with doesn't exist", System.Net.HttpStatusCode.NotFound);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.User.GetAllUsersAsync();
        }

        public async void Update(User entity)
        {
            var user = await _repository.User.GetUser(u => u.Email == entity.Email);
            if (user is null)
                throw new BusinessException($"[Update] User with name: {entity.Email} doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.User.Update(entity);
            await _repository.Save();
        }
    }
}