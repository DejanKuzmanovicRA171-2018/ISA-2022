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

        public Task Create(RegUser entity)
        {
            _repository.RegUser.CreateRegUser(entity);
            _repository.Save();
            return Task.CompletedTask;
        }

        public void Delete(RegUser entity)
        {
            _repository.RegUser.DeleteRegUser(entity);
            _repository.Save();
        }

        public async Task<RegUser> Get(Expression<Func<RegUser, bool>> expression)
        {
            return await _repository.RegUser.GetRegUser(expression);
        }

        public async Task<IEnumerable<RegUser>> GetAll()
        {
            return await _repository.RegUser.GetAllRegUsersAsync();
        }

        public void Update(RegUser entity)
        {
            _repository.RegUser.UpdateRegUser(entity);
            _repository.Save();
        }
    }
}
