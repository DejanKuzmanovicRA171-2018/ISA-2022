using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class AdminsService : IAdminsService
    {
        private readonly IRepositoryWrapper _repository;
        public AdminsService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task Create(Admin entity)
        {
            var admin = await _repository.Admin.GetAdmin(e => e.UserId == entity.UserId);
            if (admin is not null)
                throw new BusinessException($"Admin with UserId: {entity.UserId} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.Admin.CreateAdmin(entity);
            await _repository.Save();
        }

        public async Task Delete(Admin entity)
        {
            //var user = await _repository.User.GetUser(u => u.Id == entity.UserId);
            // Should never happen (Admins are created based on users)
            // if (user is null)
            //     throw new BusinessException("User for the given admin doesn't exist", System.Net.HttpStatusCode.InternalServerError);
            // entity.User = user;

            var admin = await _repository.Admin.GetAdmin(e => e.Id == entity.Id);
            if (admin is null)
                throw new BusinessException("[Delete] Admin doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Admin.DeleteAdmin(entity);
            //_repository.User.DeleteUser(user);
            await _repository.Save();
        }

        public async Task<Admin> Get(Expression<Func<Admin, bool>> expression)
        {
            var admin = await _repository.Admin.GetAdmin(expression);
            if (admin is null)
                throw new BusinessException("Admin with matching parameters doesn't exist", System.Net.HttpStatusCode.NotFound);
            return admin;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _repository.Admin.GetAllAdminsAsync();
        }

        public async Task Update(Admin entity)
        {
            var admin = await _repository.Admin.GetAdmin(e => e.UserId == entity.UserId);
            if (admin is null)
                throw new BusinessException("[Update] Admin doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Admin.UpdateAdmin(entity);
            await _repository.Save();
        }
    }
}
