using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repository;
using Repository.Interfaces;
using System.Data.Entity.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

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
           await _repository.User.Create(entity);
           await _repository.Save();
        }

        public void Delete(User entity)
        {
            _repository.User.Delete(entity);
            _repository.Save();
        }

        public async Task<User> Get(Expression<Func<User, bool>> expression)
        {
            return await _repository.User.GetUser(expression);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.User.GetAllUsersAsync();
        }

        public void Update(User entity)
        {
            _repository.User.Update(entity);
            _repository.Save();
        }
    }
}