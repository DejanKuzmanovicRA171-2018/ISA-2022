using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _repository.RegUser.Create(entity);
            _repository.Save();
            return Task.CompletedTask;
        }

        public void Delete(RegUser entity)
        {
            _repository.RegUser.Delete(entity);
            _repository.Save();
        }

        public async Task<RegUser> Get(int id)
        {
            return await _repository.RegUser.GetUser(id);
        }

        public async Task<IEnumerable<RegUser>> GetAll()
        {
            return await _repository.RegUser.GetAllUsersAsync();
        }

        public void Update(RegUser entity)
        {
            _repository.RegUser.Update(entity);
            _repository.Save();
        }
    }
}
